using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneCharacterInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<IAnimatorController>()
			.To<CharacterAnimatorController>()
			.FromComponentSibling()
			.AsTransient()
			.WhenInjectedInto<Character>();

		Container.Bind<ICharacterMovement>()
			.To<DefaultCharacterMovement>()
			.FromComponentSibling()
			.AsTransient()
			.WhenInjectedInto<Character>();

	}
}
