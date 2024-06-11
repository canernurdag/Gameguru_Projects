using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelGridInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<IGridCreator>()
			.To<GridCreator>()
			.FromComponentSibling()
			.WhenInjectedInto<GridController>();

		Container.Bind<GridCreator>()
			.FromComponentInHierarchy()
			.AsCached();

		Container.Bind<GridController>()
			.FromComponentInHierarchy()
			.WhenInjectedInto<GridSlotSelector>();

		Container.Bind<GridSlot>()
			.FromComponentsInChildren()
			.WhenInjectedInto<GridCreator>();
	}
}
