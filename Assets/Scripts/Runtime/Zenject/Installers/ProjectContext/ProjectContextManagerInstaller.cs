using Assets.Scripts.Runtime.Managers._AudioManager;
using Assets.Scripts.Runtime.Managers._GameManager;
using Assets.Scripts.Runtime.Managers._SaveManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectContextManagerInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
		Container.Bind<SaveManager>().FromComponentInHierarchy().AsSingle();
		Container.Bind<AudioManager>().FromComponentInHierarchy().AsSingle();
	}
}
