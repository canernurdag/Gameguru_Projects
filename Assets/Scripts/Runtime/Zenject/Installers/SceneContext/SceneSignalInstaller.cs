using Assets.Scripts.Runtime.Managers._CinemachineManager;
using Assets.Scripts.Runtime.Managers._UiManager;
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
		Container.DeclareSignal<SignalOnFinishSeqStart>();
		Container.DeclareSignal<SignalOnVCamChanged>();
		Container.DeclareSignal<SignalOnLevelSucess>();
		Container.DeclareSignal<SignalOnLevelFail>();
		Container.DeclareSignal<SignalOnLevelStarted>();


		Container.BindSignal<SignalOnInputDown>()
			.ToMethod<DefaultStackGroupController>(x=>x.SplitTheActiveStackPart)
			.FromResolve();

		Container.BindSignal<SignalGhostObjectTargetChanged>()
			.ToMethod<GhostObject>(x => x.SetTargetTransform)
			.FromResolve();


		Container.BindSignal<SignalOnNewStackPartGroupPlaced>()
			.ToMethod<DefaultCharacterController>(x => x.PlaceCharacterToActiveStackPartGroup)
			.FromResolve();

		Container.BindSignal<SignalOnSetActiveStackPart>()
			.ToMethod<DefaultStackGroupController>(x => x.ActivateTheStackPart)
			.FromResolve();

		Container.BindSignal<SignalOnSetActiveStackPart>()
			.ToMethod<DefaultCharacterController>(x => x.ActiveCharacterToNextStackPart)
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

		Container.BindSignal<SignalOnFinishSeqStart>()
		.	ToMethod<DefaultCharacterController>(x => x.ActiveCharacterToFinish)
			.FromResolve();

		Container.BindSignal<SignalOnFinishSeqStart>()
			.ToMethod<CinemachineManager>(x => x.StartCameraOrbitSeq)
			.FromResolve();


		Container.BindSignal<SignalOnLevelSucess>()
			.ToMethod<UiManager>(x => x.ActivateSuccessUi)
			.FromResolve();


		Container.BindSignal<SignalOnLevelFail>()
			.ToMethod<UiManager>(x => x.ActivateFailUi)
			.FromResolve();

		Container.BindSignal<SignalOnSetActiveStackPart>()
			.ToMethod<UiManager>(x => x.CloseSuccessAndFailUi)
			.FromResolve();

		Container.BindSignal<SignalOnLevelStarted>()
			.ToMethod<LevelController>(x => x.StartNextLevel)
			.FromResolve();
	}
}
