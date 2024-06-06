using Assets.Scripts.Runtime.Managers._SaveManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectContextSaveInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<ISaveSystem>()
			.To<JsonSaveSystem>()
			.FromComponentSibling()
			.AsCached()
			.WhenInjectedInto<SaveManager>();
		
	}
}
