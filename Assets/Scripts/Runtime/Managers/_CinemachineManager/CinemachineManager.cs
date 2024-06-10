using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.Managers._CinemachineManager
{
	public class CinemachineManager : MonoBehaviour
	{
		public IStateDrivenCameraController StateDrivenCameraController { get; private set; }

		[Inject]
		public void Construct(IStateDrivenCameraController stateDrivenCameraController)
		{
			StateDrivenCameraController = stateDrivenCameraController;
		}
	}
}