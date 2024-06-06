using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers._SaveManager
{
	public class JsonSaveSystem : MonoBehaviour, ISaveSystem
	{
		public SaveState SaveState { get; set; }
		private string _filePath;

		private void Awake()
		{
			_filePath = Application.persistentDataPath + "/SaveState.json";
			Load();
		}

		public void Load()
		{
			bool isSaveStateExist = File.Exists(_filePath);
			if (isSaveStateExist)
			{
				string loadData = File.ReadAllText(_filePath);
				SaveState = JsonUtility.FromJson<SaveState>(loadData);

			}
			else if (!isSaveStateExist)
			{
				SaveState = new SaveState();
				SaveState.InitSaveState();
				Save();
			}
		}

		public void Save()
		{
			string saveData = JsonUtility.ToJson(SaveState);
			File.WriteAllText(_filePath, saveData);
		}
	}
}