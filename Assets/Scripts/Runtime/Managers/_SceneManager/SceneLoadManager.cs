using Assets.Scripts.Runtime.Managers._GameManager;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.Scripts.Runtime.Managers._SceneManager
{
	public class SceneLoadManager : MonoBehaviour
	{
		private SignalBus _signalBus;

		[Inject]
		public void Construct(SignalBus signalBus)
		{
			_signalBus = signalBus;
		}

		public void OpenTargetScene(bool isAsync, int sceneIndex)
		{
			ExecuteSceneOpening(isAsync, sceneIndex);
		}

		private void ExecuteSceneOpening(bool isAsync, int levelIndex)
		{
			if (isAsync)
			{
				OpenSceneAsync(levelIndex).Forget();
			}
			else if (!isAsync)
			{
				OpenSceneSync(levelIndex);
			}
		}

		private void OpenSceneSync(int levelIndex)
		{
			SceneManager.LoadScene(levelIndex);
			_signalBus.Fire(new SignalSceneChanged(levelIndex));
		}


		private async UniTask OpenSceneAsync(int levelIndex)
		{
			var loadSceneAsync = SceneManager.LoadSceneAsync(levelIndex);

			while (!loadSceneAsync.isDone)
			{
				await UniTask.Yield(this.GetCancellationTokenOnDestroy());
			}
			_signalBus.Fire(new SignalSceneChanged(levelIndex));
		}
	}
}