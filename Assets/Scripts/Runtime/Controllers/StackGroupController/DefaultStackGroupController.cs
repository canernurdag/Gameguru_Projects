using Assets.Scripts.Runtime.Managers._GameManager;
using Assets.Scripts.Runtime.Zenject.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DefaultStackGroupController : MonoBehaviour, IStackGroupController
{
	public StackPartGroup ActiveStackPartGroup { get;  set; } = null;

	private List<StackPartGroup> _stackPartGroups = new();

	private StackPartGroup.StackPartGroupFactory _stackPartGroupFactory;
	private SignalBus _signalBus;


	[Inject]
	public void Construct(StackPartGroup.StackPartGroupFactory stackPartGroupFactory,
		SignalBus signalBus)
	{
		_stackPartGroupFactory = stackPartGroupFactory;
		_signalBus = signalBus;
	}

	public void AddNewStackPartGroup()
	{
		var newStackPartGroup = _stackPartGroupFactory.Create();
		_stackPartGroups.Add(newStackPartGroup);
		SetActiveStackPartGroup(newStackPartGroup);

		if(_stackPartGroups.Count == 1)
		{
			newStackPartGroup.transform.position = Vector3.zero;
		}
		else if(_stackPartGroups.Count > 1)
		{
			var previousStackPartGroup = _stackPartGroups[^2];
			newStackPartGroup.transform.position = previousStackPartGroup.NextStackPartGroupPosition.position;
		}

		newStackPartGroup.InitStackPartGroup();

		_signalBus.Fire(new SignalOnNewStackPartGroupPlaced(newStackPartGroup));
	}



	public void SetActiveStackPartGroup(StackPartGroup stackPartGroup)
	{
		ActiveStackPartGroup = stackPartGroup;
	}

	public void SplitTheActiveStackPart(SignalOnInputDown signalOnInputDown)
	{
		var activeStackPart = ActiveStackPartGroup.ActiveStackPart;
		var previousStackPart = ActiveStackPartGroup.PreviousStackPart;

		activeStackPart.StackPartMover.StopMovement();

		var distance = activeStackPart.transform.position.x - previousStackPart.transform.position.x;


		var totalHalfWidth = 
			(activeStackPart.StackPartVisual.GetCurrentWidth()/2) 
			+ (previousStackPart.StackPartVisual.GetCurrentWidth()/2);

		if (Mathf.Abs(distance) > totalHalfWidth) 
		{
			_signalBus.Fire(new SignalGameStateChanged(GameStateType.GameFinished));
			_signalBus.Fire(new SignalOnLevelFail());
			activeStackPart.StackPartPhysicsProvider.SetPhysicsActiveness(true);

			return;
		}


		var percentage = distance / activeStackPart.StackPartVisual.GetCurrentWidth();

		activeStackPart.StackPartSplitter.Split(percentage, previousStackPart); 
	}

	public void ActivateTheStackPart(SignalOnSetActiveStackPart signalOnSetActiveStackPart)
	{
		signalOnSetActiveStackPart.StackPart.Activate(signalOnSetActiveStackPart.PreviousStackPart);
	}

}
