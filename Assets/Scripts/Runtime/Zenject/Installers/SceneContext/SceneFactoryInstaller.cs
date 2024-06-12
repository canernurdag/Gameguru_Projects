using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneFactoryInstaller : MonoInstaller
{
	[SerializeField] private StackPartGroup _stackPartGroupPrefab;
	[SerializeField] private Character _characterPrefab;
	[SerializeField] private StackPart _stackPartPrefab;
	public override void InstallBindings()
	{
		Container.BindFactory<StackPartGroup, StackPartGroup.StackPartGroupFactory>()
			.FromComponentInNewPrefab(_stackPartGroupPrefab);

		Container.BindFactory<Character, Character.CharacterFactory>()
			.FromComponentInNewPrefab(_characterPrefab);

		Container.BindFactory<StackPart, StackPart.StackPartFactory>()
			.FromComponentInNewPrefab(_stackPartPrefab);
	}
}
