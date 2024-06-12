using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SFXController : MonoBehaviour
{
	#region DIRECT REF
	[SerializeField] private AudioClip _successClip;
	[SerializeField] private AudioClip _failClip;
	[SerializeField] private AudioSource _audioSource;
	[SerializeField] private int _maxStreakCountForPitch;
	#endregion

	#region DI REf
	private IStreakController _streakController;
	#endregion


	[Inject]
	public void Construct(IStreakController streakController)
	{
		_streakController = streakController;
	}

	public void PLaySuccess(SignalOnStreakIncrease signalOnStreakIncrease)
	{
		_audioSource.pitch = 1 + GetPitch();
		_audioSource.clip = _successClip;
		_audioSource.Play();
	}

	public void PlayFail(SignalOnStreakBreak signalOnStreakBreak)
	{
		_audioSource.pitch = 1;
		_audioSource.clip = _failClip;
		_audioSource.Play();
	}

	private float GetPitch()
	{
		float ratio = (float)_streakController.StreakCount / (float)_maxStreakCountForPitch;
		return ratio;
	}
}
