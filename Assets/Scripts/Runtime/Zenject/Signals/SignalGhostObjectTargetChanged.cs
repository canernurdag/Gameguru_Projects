using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalGhostObjectTargetChanged 
{
    public Transform TargetTransform;

	public SignalGhostObjectTargetChanged(Transform targetTransform)
	{
		TargetTransform = targetTransform;
	}
}
