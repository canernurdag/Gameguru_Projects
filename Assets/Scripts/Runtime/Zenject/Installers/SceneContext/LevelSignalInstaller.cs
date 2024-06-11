using Assets.Scripts.Runtime.Managers._CinemachineManager;
using Assets.Scripts.Runtime.Zenject.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelSignalInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		SignalBusInstaller.Install(Container);

		//SIGNAL DECLARATION
		Container.DeclareSignal<SignalCameraOthSizeChanged>();
		Container.BindSignal<SignalCameraOthSizeChanged>()
			.ToMethod<CinemachineManager>(x => x.SetCurrentVcamOrthSize)
			.FromResolve();

	}
}
