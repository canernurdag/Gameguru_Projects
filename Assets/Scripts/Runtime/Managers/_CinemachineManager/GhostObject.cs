using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostObject : MonoBehaviour
{
	[SerializeField]private Transform _targetTransform;

	private void LateUpdate()
	{
		if (_targetTransform)
		{
			transform.position = _targetTransform.transform.position;
		}
	}

	public void SetTargetTransform(Transform targetTransform)
	{
		_targetTransform = targetTransform;
	}

	public void SetTargetTransform(SignalGhostObjectTargetChanged signalGhostObjectTargetChanged)
	{
		_targetTransform = signalGhostObjectTargetChanged.TargetTransform;
	}
}
