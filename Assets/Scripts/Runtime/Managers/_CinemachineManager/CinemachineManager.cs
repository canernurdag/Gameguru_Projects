using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.Managers._CinemachineManager
{
	public class CinemachineManager : MonoBehaviour
	{
		public IStateDrivenCameraController StateDrivenCameraController { get; private set; }
		public IVirtualCameraController VirtualCameraController { get; private set; }

		[Inject]
		public void Construct(IStateDrivenCameraController stateDrivenCameraController, IVirtualCameraController virtualCameraController)
		{
			StateDrivenCameraController = stateDrivenCameraController;
			VirtualCameraController = virtualCameraController;
		}


		public void SetCurrentVcamOrthSize(SignalCameraOthSizeChanged signalCameraOthSizeChanged)
		{
			var currentVcam = StateDrivenCameraController.GetActiveVcam();
			VirtualCameraController.SetOrthoSize(currentVcam, signalCameraOthSizeChanged.TotalWidth);
		}
	}
}