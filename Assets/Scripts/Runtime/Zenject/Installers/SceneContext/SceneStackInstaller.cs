using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneStackInstaller : MonoInstaller
{

	public override void InstallBindings()
	{
		Container.Bind<StackPartGroup>()
			.FromComponentInHierarchy()
			.AsCached();

		Container.Bind<IStackPartMover>()
			.To<DefaultStackPartMover>()
			.FromComponentSibling()
			.AsTransient();

		Container.Bind<IStackPartSplitter>()
			.To<DefaultStackPartSplitter>()
			.FromComponentSibling()
			.AsTransient();

		Container.Bind<IStackPartPhysicsProvider>()
			.To<DefaultStackPartPhysicsProvider>()
			.FromComponentSibling()
			.AsTransient();

		Container.Bind<IStackPartVisual>()
			.To<DefaultStackPartVisual>()
			.FromComponentSibling()
			.AsTransient();

		Container.Bind<StackPart>()
			.FromComponentsInChildren()
			.AsTransient()
			.WhenInjectedInto<StackPartGroup>();

		Container.Bind<StackPart>()
			.FromComponentSibling()
			.AsTransient()
			.WhenInjectedInto<DefaultStackPartSplitter>();

		Container.Bind<Finish>()
			.FromComponentInChildren()
			.AsTransient()
			.WhenInjectedInto<StackPartGroup>();
	}
}
