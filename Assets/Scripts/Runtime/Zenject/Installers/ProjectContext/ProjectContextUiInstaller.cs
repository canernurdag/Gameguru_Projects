using Assets.Scripts.Runtime.Managers._SaveManager;
using Assets.Scripts.Runtime.Managers._UiManager;
using Assets.Scripts.Runtime.Managers._UiManager.ControlCanvas;
using Assets.Scripts.Runtime.Managers._UiManager.ControlView;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectContextUiInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<CanvasBase>()
			.FromComponentsInChildren()
			.WhenInjectedInto<DefaultControlCanvas>();

		Container.Bind<IControlCanvas>()
			.To<DefaultControlCanvas>()
			.FromComponentSibling()
			.WhenInjectedInto<UiManager>();

		Container.Bind<IControlView>()
			.To<DefaultControlView>()
			.FromComponentSibling()
			.WhenInjectedInto<UiManager>();

	}
}
