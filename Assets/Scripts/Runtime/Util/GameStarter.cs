using Assets.Scripts.Runtime.Managers._SceneManager;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameStarter : MonoBehaviour
{
	private SceneLoadManager _sceneLoadManager;

	[Inject]
	public void Construct(SceneLoadManager sceneLoadManager)
	{
		_sceneLoadManager = sceneLoadManager;
	}

	private void Start()
	{
		DOVirtual.DelayedCall(2f, () =>
		{
			_sceneLoadManager.OpenTargetScene(true, 1);
		});
	}
}
