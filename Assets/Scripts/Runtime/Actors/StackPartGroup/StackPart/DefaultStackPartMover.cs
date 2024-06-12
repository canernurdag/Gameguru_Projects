using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultStackPartMover : MonoBehaviour, IStackPartMover
{
	[SerializeField] private float _startingDistance;
	[SerializeField] private float _movementDuration;
	private Tween _moveTween;

	public void Move()
	{
		transform.position += Vector3.right * _startingDistance;
		Vector3 targetPos = new Vector3(
			-transform.position.x,
			transform.position.y,
			transform.position.z);

		_moveTween?.Kill();
		_moveTween = transform.DOMove(targetPos, _movementDuration)
			.SetEase(Ease.Linear)
			.SetLoops(-1, LoopType.Yoyo);
	}

	public void StopMovement()
	{
		_moveTween?.Kill();
	}
}
