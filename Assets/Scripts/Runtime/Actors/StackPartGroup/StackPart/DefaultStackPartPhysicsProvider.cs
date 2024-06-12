using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DefaultStackPartPhysicsProvider : MonoBehaviour, IStackPartPhysicsProvider
{
	[field: SerializeField] public Rigidbody Rigidbody { get; set;}
	[field: SerializeField] public BoxCollider BoxCollider { get; set; }

	public void SetPhysicsActiveness(bool isActive)
	{
		Rigidbody.isKinematic = !isActive;
	}
}
