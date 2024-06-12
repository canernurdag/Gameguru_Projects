using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class DefaultStackPartSplitter : MonoBehaviour, IStackPartSplitter
{
	#region DI REF
	private StackPart _stackPart;
	private StackPart.StackPartFactory _stackPartFactory;
	private StackGroupController _stackGroupController;
	private SignalBus _signalBus;
	#endregion

	#region DIRECT REF
	[SerializeField] private float _thresholdPercentagePerfectPlacement = 0.15f;
	#endregion


	[Inject]
	public void Construct(
		StackPart stackPart,
		StackPart.StackPartFactory stackPartFactory,
		StackGroupController stackGroupController,
		SignalBus signalBus)
	{
		_stackPart = stackPart;
		_stackPartFactory = stackPartFactory;
		_stackGroupController = stackGroupController;
		_signalBus = signalBus;
	}



	public void Split(float percentage, StackPart previosStackPart)
	{
		if(percentage < _thresholdPercentagePerfectPlacement)
		{
			percentage = 0;

			transform.position = new Vector3(
			previosStackPart.transform.position.x,
			previosStackPart.transform.position.y,
			_stackPart.transform.position.z);

			var next_StackPart = _stackGroupController.ActiveStackPartGroup.GetNextStackPartInTheList();
			_stackGroupController.ActiveStackPartGroup.SetActiveStackPartAndPreviousStackPart(next_StackPart, _stackPart);

			_signalBus.Fire(new SignalOnStreakIncrease());
		}
		else
		{
			bool isStackPartFallLeftSide = percentage < 0;


			StackPart stackPartFall = _stackPartFactory.Create();
			StackPart stackPartStand = _stackPartFactory.Create();
			_stackPart.gameObject.SetActive(false);
			var currentMaterial = _stackPart.StackPartVisual.MeshRenderer.material;

			//MATERIALS
			stackPartFall.StackPartVisual.SetMaterial(currentMaterial);
			stackPartStand.StackPartVisual.SetMaterial(currentMaterial);

			//SCALE
			Vector3 stackPartLocalScale = _stackPart.transform.localScale;

			//SCALE_Fall
			float stackPartFallScaleX = Mathf.Abs(percentage);
			stackPartFall.transform.localScale = new Vector3(stackPartFallScaleX * _stackPart.StackPartVisual.GetCurrentWidth(), stackPartLocalScale.y, stackPartLocalScale.z);

			//SCALE_Stand
			float stackPartStandScaleX = Mathf.Abs((1 - Mathf.Abs(percentage)));
			stackPartStand.transform.localScale = new Vector3(stackPartStandScaleX * _stackPart.StackPartVisual.GetCurrentWidth(), stackPartLocalScale.y, stackPartLocalScale.z);


			// POSITION
			var directionStackPartFall = isStackPartFallLeftSide ? StackMovementDirection.Left : StackMovementDirection.Right;
			var stackPartFallPosition = GetEdgePosition(previosStackPart.StackPartVisual.MeshRenderer, directionStackPartFall);

			//POSITION_Fall
			var directionMultiplierFall = isStackPartFallLeftSide ? -1 : 1;
			Vector3 newPosition = new Vector3(stackPartFallPosition.x, transform.position.y, transform.position.z);
			newPosition.x += (stackPartFallScaleX / 2) * _stackPart.StackPartVisual.GetCurrentWidth() * directionMultiplierFall;
			stackPartFall.transform.position = newPosition;

			//POSITION_STAND
			var directionMultiplierStand = isStackPartFallLeftSide ? 1 : -1;
			Vector3 newPosition2 = new Vector3(stackPartFallPosition.x, transform.position.y, transform.position.z);
			newPosition2.x += (stackPartStandScaleX / 2) * _stackPart.StackPartVisual.GetCurrentWidth() * directionMultiplierStand;
			stackPartStand.transform.position = newPosition2;

			//SetNewPrevious Here
			var nextStackPart = _stackGroupController.ActiveStackPartGroup.GetNextStackPartInTheList();
			_stackGroupController.ActiveStackPartGroup.SetActiveStackPartAndPreviousStackPart(nextStackPart, stackPartStand);


			//Physics
			stackPartFall.StackPartPhysicsProvider.SetPhysicsActiveness(true);

			_signalBus.Fire(new SignalOnStreakBreak());
		}

	

	}

	private Vector3 GetEdgePosition(MeshRenderer meshRenderer, StackMovementDirection direction)
	{
		var extends = meshRenderer.bounds.extents;
		var position = meshRenderer.transform.position;

		switch (direction)
		{
			case StackMovementDirection.Left:
				position.x += -extends.x;
				break;
			case StackMovementDirection.Right:
				position.x += extends.x;
				break;
		}
		
		return position;
	}

}

