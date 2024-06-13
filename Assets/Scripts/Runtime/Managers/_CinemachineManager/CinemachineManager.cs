using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.Managers._CinemachineManager
{
	public class CinemachineManager : MonoBehaviour
	{

		public string GameVCAM = "Game";
		public string EndVCAM = "End";

		#region DIRECT REF
		[SerializeField] private CinemachineVirtualCamera _orbitVCAM;
		[SerializeField] private float _orbitSpeed;
		#endregion

		#region DI REF
		public IStateDrivenCameraController StateDrivenCameraController { get; private set; }
		private SignalBus _signalBus;
		#endregion


		[Inject]
		public void Construct(
			IStateDrivenCameraController stateDrivenCameraController,
			LevelController levelController,
			SignalBus signalBus)
		{
			StateDrivenCameraController = stateDrivenCameraController;
			_signalBus = signalBus;
		}

		public void SetVcam(SignalOnVCamChanged signalOnVCamChanged)
		{
			StateDrivenCameraController.SetActiveVCamByAnimatorState(signalOnVCamChanged.VcamAnimParam);
		}


		public void StartCameraOrbitSeq(SignalOnFinishSeqStart signalOnFinishSeqStart)
		{
			StartCoroutine(CameraOrbitSeq());
		}
		public IEnumerator CameraOrbitSeq()
		{
			var orbital = _orbitVCAM.GetCinemachineComponent<CinemachineOrbitalTransposer>();
			orbital.m_Heading.m_Bias = 0f;
			while(orbital.m_Heading.m_Bias < 360)
			{
				orbital.m_Heading.m_Bias += Time.deltaTime* _orbitSpeed;
				yield return null;

			}

			yield return new WaitForSeconds(2);
			SetVcam(new SignalOnVCamChanged(GameVCAM));
			_signalBus.Fire(new SignalOnLevelStarted());
		
		}
	}
}