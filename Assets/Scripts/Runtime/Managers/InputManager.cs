using Assets.Scripts.Runtime.Managers._GameManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputManager : MonoBehaviour
{
	private SignalBus _signalBus;
	private GameManager _gameManager;

	[Inject]
	public void Construct(SignalBus signalBus, GameManager gameManager)
	{
		_gameManager = gameManager;
		_signalBus = signalBus;
	}

	private void Update()
	{
		if (_gameManager.CurrentGameStateType != GameStateType.GameStarted) return;

		if (Input.GetMouseButtonDown(0))
		{
			_signalBus.Fire(new SignalOnInputDown());
		}
	}
}
