using Assets.Scripts.Runtime.Managers._CinemachineManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelManagerInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<CinemachineManager>()
			.FromComponentInHierarchy()
			.AsSingle();
	}
}
