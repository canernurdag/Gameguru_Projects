using Assets.Scripts.Runtime.Managers._GameManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelController : MonoBehaviour, IStreakController
{

	#region DI REF
	private CharacterController _characterController;
	private StackGroupController _stackController;
	private GameManager _gameManager;

	#endregion


	public int StreakCount { get;  set; } = 0;


	[Inject]
	public void Construct(
		StackGroupController stackController,
		CharacterController characterController,
		GameManager gameManager
		)
	{
		_stackController = stackController;
		_characterController = characterController;
		_gameManager = gameManager;
	}

	private void Start()
	{
		InitTheFirstLevel();
	}

	private void InitTheFirstLevel()
	{
		_characterController.CreateActiveCharacter();
		_stackController.AddNewStackPartGroup();
		_gameManager.SetCurrentGameStateType(GameStateType.GameStarted);

	}

	public void SetStreakCount(int count)
	{
		StreakCount = count;
	}

	public void IncreaseStreakCount(SignalOnStreakIncrease signalOnStreakIncrease)
	{
		SetStreakCount(StreakCount + 1);
	}

	public void ResetStreakCount(SignalOnStreakBreak signalOnStreakBreak)
	{
		SetStreakCount(0);
	}


}

