using Assets.Scripts.Runtime.Managers._CinemachineManager;
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
		Container.DeclareSignal<SignalGhostObjectTargetChanged>();	
		Container.DeclareSignal<SignalOnNewStackPartGroupPlaced>();
		Container.DeclareSignal<SignalOnSetActiveStackPart>();
		Container.DeclareSignal<SignalOnStreakIncrease>();
		Container.DeclareSignal<SignalOnStreakBreak>();
		Container.DeclareSignal<SignalOnFinishlSeqStart>();
		Container.DeclareSignal<SignalOnVCamChanged>();


		Container.BindSignal<SignalOnInputDown>()
			.ToMethod<StackGroupController>(x=>x.SplitTheActiveStackPart)
			.FromResolve();

		Container.BindSignal<SignalGhostObjectTargetChanged>()
			.ToMethod<GhostObject>(x => x.SetTargetTransform)
			.FromResolve();


		Container.BindSignal<SignalOnNewStackPartGroupPlaced>()
			.ToMethod<StackPartGroup>(x => x.InitStackPartGroup)
			.FromResolve();

		Container.BindSignal<SignalOnNewStackPartGroupPlaced>()
			.ToMethod<CharacterController>(x => x.PlaceCharacterToActiveStackPartGroup)
			.FromResolve();

		Container.BindSignal<SignalOnNewStackPartGroupPlaced>()
			.ToMethod<CharacterController>(x => x.PlaceCharacterToActiveStackPartGroup)
			.FromResolve();

		Container.BindSignal<SignalOnSetActiveStackPart>()
			.ToMethod<StackGroupController>(x => x.ActivateTheStackPart)
			.FromResolve();

		Container.BindSignal<SignalOnSetActiveStackPart>()
			.ToMethod<CharacterController>(x => x.ActiveCharacterToNextStackPart)
			.FromResolve();

		Container.BindSignal<SignalOnStreakIncrease>()
			.ToMethod<LevelController>(x => x.IncreaseStreakCount)
			.FromResolve();

		Container.BindSignal<SignalOnStreakBreak>()
			.ToMethod<LevelController>(x => x.ResetStreakCount)
			.FromResolve();

		Container.BindSignal<SignalOnStreakIncrease>()
			.ToMethod<SFXController>(x => x.PLaySuccess)
			.FromResolve();

		Container.BindSignal<SignalOnStreakBreak>()
			.ToMethod<SFXController>(x => x.PlayFail)
			.FromResolve();


		Container.BindSignal<SignalOnVCamChanged>()
			.ToMethod<CinemachineManager>(x => x.SetVcam)
			.FromResolve();

		Container.BindSignal<SignalOnFinishlSeqStart>()
		.ToMethod<CharacterController>(x => x.ActiveCharacterToFinish)
			.FromResolve();


	}
}
