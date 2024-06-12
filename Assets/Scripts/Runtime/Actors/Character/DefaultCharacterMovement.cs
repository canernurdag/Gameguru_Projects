using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCharacterMovement : MonoBehaviour, ICharacterMovement
{
	[SerializeField] private float _speed;
	private Tween _moveTween;

	public void Move(Vector3 targetPos, Action callback)
	{
		_moveTween?.Kill();
		_moveTween = transform.DOMove(targetPos, _speed)
			.SetEase(Ease.Linear)
			.SetSpeedBased()
			.OnComplete(() => callback());
	}
}
