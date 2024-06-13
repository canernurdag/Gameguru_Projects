using Assets.Scripts.Runtime.Managers._CinemachineManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Character;
using Zenject;

public interface ICharacterController
{
	public Character ActiveCharacter { get;  set; }
	void CreateActiveCharacter();
	void PlaceCharacterToActiveStackPartGroup(SignalOnNewStackPartGroupPlaced signalOnNewStackPartGroupPlaced);
	void ActiveCharacterToNextStackPart(SignalOnSetActiveStackPart signalOnSetActiveStackPart);
	void ActiveCharacterToFinish(SignalOnFinishSeqStart signalOnFinishlineSeq);
	
}
