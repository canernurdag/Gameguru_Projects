using Assets.Scripts.Runtime.Managers._CinemachineManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DefaultCharacterController : MonoBehaviour, ICharacterController
{
	#region DI REF
	private Character.CharacterFactory _characterFactory;
	private SignalBus _signalBus;
	private CinemachineManager _cinemachineManager;
	#endregion
	public Character ActiveCharacter { get;  set; }
	
	[Inject]
	public void Construct(Character.CharacterFactory characterFactory, SignalBus signalBus, CinemachineManager cinemachineManager)
	{
		_characterFactory = characterFactory;
		_signalBus = signalBus;
		_cinemachineManager = cinemachineManager;
	}

	public void CreateActiveCharacter()
	{
		Character character = _characterFactory.Create();
		ActiveCharacter = character;

		_signalBus.Fire(new SignalGhostObjectTargetChanged(ActiveCharacter.transform));
	}

	public void PlaceCharacterToActiveStackPartGroup(SignalOnNewStackPartGroupPlaced signalOnNewStackPartGroupPlaced)
	{
		var newStackPartGroup = signalOnNewStackPartGroupPlaced.StackPartGroup;
		ActiveCharacter.transform.position = newStackPartGroup.GetCharacterInitPos();
	}

	public void ActiveCharacterToNextStackPart(SignalOnSetActiveStackPart signalOnSetActiveStackPart)
	{
		ActiveCharacter.CharacterAnimatorController.SetCurrentAnimatorState(ActiveCharacter.CharacterAnimatorController.Run);
		ActiveCharacter.CharacterMovement.Move(signalOnSetActiveStackPart.PreviousStackPart.CharacterPosition.position, 
		() =>
		{
			ActiveCharacter.CharacterAnimatorController.SetCurrentAnimatorState(ActiveCharacter.CharacterAnimatorController.Idle);
		});
	}

	public void ActiveCharacterToFinish(SignalOnFinishSeqStart signalOnFinishlineSeq)
	{
		ActiveCharacter.CharacterAnimatorController.SetCurrentAnimatorState(ActiveCharacter.CharacterAnimatorController.Run);
		ActiveCharacter.CharacterMovement.Move(signalOnFinishlineSeq.Finish.CharacterPosition.position,
		() =>
		{
			ActiveCharacter.CharacterAnimatorController.SetCurrentAnimatorState(ActiveCharacter.CharacterAnimatorController.Dance);
			_signalBus.Fire(new SignalOnVCamChanged(_cinemachineManager.EndVCAM));
		});
	}
}
