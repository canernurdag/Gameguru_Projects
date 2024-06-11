using Assets.Scripts.Runtime.Zenject.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneSignalInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.DeclareSignal<SignalOnInputDown>();
		
	}
}
