using Assets.Scripts.Runtime.Managers._GameManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelController : MonoBehaviour, IStreakController
{

	#region DI REF
	private ICharacterController _characterController;
	private IStackGroupController _stackGroupController;
	private GameManager _gameManager;

	#endregion


	public int StreakCount { get;  set; } = 0;


	[Inject]
	public void Construct(
		IStackGroupController stackController,
		ICharacterController characterController,
		GameManager gameManager
		)
	{
		_stackGroupController = stackController;
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
		StartNextLevel(null);

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

	public void StartNextLevel(SignalOnLevelStarted signalOnLevelStarted)
	{
		_stackGroupController.AddNewStackPartGroup();
		_gameManager.SetCurrentGameStateType(GameStateType.GameStarted);
	}


}

