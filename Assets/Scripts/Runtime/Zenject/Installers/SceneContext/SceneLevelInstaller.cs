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


		Container.Bind<ICharacterController>()
			.To<DefaultCharacterController>()
			.FromComponentInHierarchy()
			.AsCached();

		Container.Bind<DefaultCharacterController>()
			.FromComponentInHierarchy()
			.AsCached();

		Container.Bind<IStackGroupController>()
			.To<DefaultStackGroupController>()
			.FromComponentInHierarchy()
			.AsCached();

		Container.Bind<DefaultStackGroupController>()
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
