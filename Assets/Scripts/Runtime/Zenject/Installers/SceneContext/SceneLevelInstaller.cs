using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneLevelInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<LevelController>()
			.FromComponentInHierarchy()
			.AsCached();
		
		Container.Bind<CharacterController>()
			.FromComponentInHierarchy()
			.AsCached();


		Container.Bind<StackGroupController>()
			.FromComponentInHierarchy()
			.AsCached();

		Container.Bind<IStreakController>()
			.To<LevelController>()
			.FromComponentInHierarchy()
			.AsCached();

		Container.Bind<SFXController>()
			.FromComponentInHierarchy()
			.AsCached();

	}
}
