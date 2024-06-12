using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStackPartPhysicsProvider
{
	Rigidbody Rigidbody { get; set; }
	BoxCollider BoxCollider { get; set; }

	void SetPhysicsActiveness(bool isActive);
}
