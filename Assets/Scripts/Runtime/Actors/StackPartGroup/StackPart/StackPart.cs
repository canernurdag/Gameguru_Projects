using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class StackPart : MonoBehaviour
{
	public class StackPartFactory : PlaceholderFactory<StackPart>
	{

	}


	#region DIRECT REF
	[field:SerializeField] public Transform CharacterPosition {  get; private set; }
	#endregion
	#region DI REF
	public IStackPartSplitter StackPartSplitter { get; private set; }
	public IStackPartMover StackPartMover { get; private set; }
	public IStackPartPhysicsProvider StackPartPhysicsProvider { get; private set; }
	public IStackPartVisual StackPartVisual { get; private set; }
	#endregion


	[Inject]
	public void Construct(
		IStackPartSplitter stackPartSplitter,
		IStackPartMover stackPartMover,
		IStackPartPhysicsProvider stackPartPhysicsProvider,
		IStackPartVisual stackPartVisual)
	{
		StackPartMover = stackPartMover;
		StackPartSplitter = stackPartSplitter;
		StackPartPhysicsProvider = stackPartPhysicsProvider;
		StackPartVisual = stackPartVisual;
	}



	public void Activate(StackPart previousStackPart)
	{
		gameObject.SetActive(true);
		gameObject.transform.localScale = previousStackPart.transform.localScale;
		StackPartMover.Move();
	}
}
