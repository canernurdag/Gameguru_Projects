using System;

namespace Assets.Scripts.Runtime.Managers._SaveManager
{
	[Serializable]
	public class SaveState
	{
		public int LastLevelIndex;

		public bool IsAudioOn;

		public void InitSaveState()
		{
			LastLevelIndex = 0;
			IsAudioOn = true;
		}
	}
}