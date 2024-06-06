using Assets.Scripts.Runtime.Managers._SaveManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.Managers._AudioManager
{
	public class AudioManager : MonoBehaviour
	{
		#region DI REF
		private SaveManager _saveManager;
		#endregion

		[Inject]
		public void Construct(SaveManager saveManager)
		{
			_saveManager = saveManager;
		}

		public void PlayAudioClip(AudioSource audioSource, AudioClip audioClip, float volumeMultiplier = 1)
		{
			if (!_saveManager.SaveSystem.SaveState.IsAudioOn) return;
			audioSource.PlayOneShot(audioClip, volumeMultiplier);
		}

		public void PlayAudioClipInPoint(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1)
		{
			if (!_saveManager.SaveSystem.SaveState.IsAudioOn) return;
			AudioSource.PlayClipAtPoint(audioClip, position, volumeMultiplier);
		}
	}
}