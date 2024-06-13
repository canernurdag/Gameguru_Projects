using Assets.Scripts.Runtime.Managers._UiManager._View._View.Abstract;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewLevelResult : ViewBase
{
	private Tween _scaleTween;
	public override void Hide()
	{
		gameObject.SetActive(false);
	}

	public override void Initialize()
	{
		
	}

	public override void Show()
	{
		gameObject.SetActive(true);
		transform.localScale = Vector3.zero;
		_scaleTween?.Kill();
		_scaleTween = transform.DOScale(Vector3.one, 0.4f);
	}
}
