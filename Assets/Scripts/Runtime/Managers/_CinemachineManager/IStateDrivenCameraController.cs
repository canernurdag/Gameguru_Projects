using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers._CinemachineManager
{
	public interface IStateDrivenCameraController
	{
		void SetActiveVCamByAnimatorState(string animParam);
		CinemachineVirtualCamera GetActiveVcam();
	}
}