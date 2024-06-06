using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.Managers._SaveManager
{
	public class SaveManager : MonoBehaviour
	{
		public ISaveSystem SaveSystem { get; private set; }

		[Inject]
		public void Construct(ISaveSystem saveSystem)
		{
			SaveSystem = saveSystem;
		}

		private void OnApplicationFocus(bool focus)
		{
			if (!focus) SaveSystem.Save();
		}

		private void OnApplicationPause(bool pause)
		{
			if (pause) SaveSystem.Save();

		}

		private void OnApplicationQuit()
		{
			SaveSystem.Save();
		}
	}
}