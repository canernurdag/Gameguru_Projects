using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelFactoryInstaller : MonoInstaller
{
	[SerializeField] private GridSlot _gridSlotPrefab;

	public override void InstallBindings()
	{
		Container.BindFactory<GridSlot, GridSlot.GridSlotFactory>()
			.FromComponentInNewPrefab(_gridSlotPrefab);
	}
}
