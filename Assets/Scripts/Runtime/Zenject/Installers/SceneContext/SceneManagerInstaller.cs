using Assets.Scripts.Runtime.Managers._CinemachineManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneManagerInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<CinemachineManager>()
			.FromComponentInHierarchy()
			.AsCached();

		Container.Bind<IStateDrivenCameraController>()
			.To<DefaultStateDrivenCameraController>()
			.FromComponentInHierarchy()
			.AsCached();
	}
}
