using Assets.Scripts.Runtime.Managers._CinemachineManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelCinemachineInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<IStateDrivenCameraController>()
			.To<DefaultStateDrivenCameraController>()
			.FromComponentSibling()
			.WhenInjectedInto<CinemachineManager>();

		Container.Bind<IVirtualCameraController>()
			.To<DefaultVirtualCameraController>()
			.FromComponentSibling()
			.WhenInjectedInto<CinemachineManager>();
	}
}
