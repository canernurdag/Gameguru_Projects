using Assets.Scripts.Runtime.Managers._AudioManager;
using Assets.Scripts.Runtime.Managers._GameManager;
using Assets.Scripts.Runtime.Managers._SaveManager;
using Assets.Scripts.Runtime.Managers._SceneManager;
using Assets.Scripts.Runtime.Managers._UiManager;
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
		Container.Bind<SceneLoadManager>().FromComponentInHierarchy().AsSingle();
		Container.Bind<UiManager>().FromComponentInHierarchy().AsSingle();
	}
}
