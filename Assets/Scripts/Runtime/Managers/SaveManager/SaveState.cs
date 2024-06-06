using System;

namespace Assets.Scripts.Runtime.Managers
{
	[Serializable]
	public class SaveState
	{
		public int LastLevelIndex;

		public void InitSaveState()
		{
			LastLevelIndex = 0;
		}
	}
}