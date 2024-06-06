using Assets.Scripts.Runtime.Zenject.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.Managers.GameManager
{
	public sealed class GameManager : MonoBehaviour
	{
		private SignalBus _signalBus;
		public GameStateType CurrentGameStateType { get; private set; }

		[Inject]
		public void Construct(SignalBus signalBus)
		{
			_signalBus = signalBus;
		}

		private void Awake()
		{
			SetQualityAndFPS();
		}

		private void SetQualityAndFPS()
		{
#if UNITY_ANDROID || UNITY_IOS
			QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = 60;
#endif
		}

		public void SetCurrentGameStateType(GameStateType gameStateType)
		{
			CurrentGameStateType = gameStateType;
			_signalBus.Fire(new SignalGameStateChanged(gameStateType));

		}

	}
}