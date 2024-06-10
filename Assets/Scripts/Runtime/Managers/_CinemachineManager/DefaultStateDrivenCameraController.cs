using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers._CinemachineManager
{
	public class DefaultStateDrivenCameraController : MonoBehaviour, IStateDrivenCameraController
	{
		[SerializeField] private Animator _stateDrivenAnimator;
		[SerializeField] private CinemachineStateDrivenCamera _cinemachineStateDrivenCamera;

		public CinemachineVirtualCamera GetActiveVcam()
		{
			return (CinemachineVirtualCamera)_cinemachineStateDrivenCamera.LiveChild;
		}

		public void SetActiveVCamByAnimatorState(string animParam)
		{
			_stateDrivenAnimator.SetTrigger(animParam);
		}
	}
}