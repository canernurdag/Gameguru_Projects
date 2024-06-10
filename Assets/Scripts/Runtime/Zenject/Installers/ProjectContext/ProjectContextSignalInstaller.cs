using Assets.Scripts.Runtime.Zenject.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectContextSignalInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		SignalBusInstaller.Install(Container);

		//SIGNAL DECLARATION
		Container.DeclareSignal<SignalGameStateChanged>();
		Container.DeclareSignal<SignalSceneChanged>();
	}
}
