using Assets.Scripts.Runtime.Managers._GameManager;
using Assets.Scripts.Runtime.Zenject.Signals;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class StackPartGroup : MonoBehaviour
{

	public class StackPartGroupFactory : PlaceholderFactory<StackPartGroup>
	{

	}

	#region DI REF
	public List<StackPart> StackParts { get; private set; } = new();
	
	private SignalBus _signalBus;

	#endregion

	#region DIRECT REF
	[field: SerializeField] public Transform NextStackPartGroupPosition;
	[field: SerializeField] public Finish Finish { get; private set; }
	#endregion

	#region PROPs
	public StackPart ActiveStackPart { get; private set; } = null;
	public StackPart PreviousStackPart { get; private set; } = null;
	#endregion
	[Inject]
	public void Construct(StackPart[] stackParts, SignalBus signalBus)
	{
		StackParts = stackParts.ToList();
		_signalBus = signalBus;
	}


	public void InitStackPartGroup()
	{
		for (int i = 2; i < StackParts.Count; i++)
		{
			var stackPart = StackParts[i];
			stackPart.gameObject.SetActive(false);
		}

		SetActiveStackPartAndPreviousStackPart(StackParts[1], StackParts[0]);

	}

	public void SetActiveStackPartAndPreviousStackPart(StackPart stackPart, StackPart previousStackPart)
	{
		if(stackPart != null)
		{
			ActiveStackPart = stackPart;
			SetPreviousStackPart(previousStackPart);
			_signalBus.Fire(new SignalOnSetActiveStackPart(stackPart, previousStackPart));
		}
		else if(stackPart== null)
		{
			_signalBus.Fire(new SignalOnFinishSeqStart(Finish));
			_signalBus.Fire(new SignalGameStateChanged(GameStateType.GameFinished));
			_signalBus.Fire(new SignalOnLevelSucess());

		}

	}

	public void SetPreviousStackPart(StackPart previousStackPart)
	{
		PreviousStackPart = previousStackPart;
	}

	public StackPart GetNextStackPartInTheList()
	{
		var index = StackParts.IndexOf(ActiveStackPart);
		if(index < StackParts.Count-1)
		{
			var nextIndex = index + 1;

			var nextStackPart = StackParts[nextIndex];
			return nextStackPart;
		}
		

		return null;

	}

	public Vector3 GetCharacterInitPos()
	{
		return StackParts[0].CharacterPosition.position;
	}
}
