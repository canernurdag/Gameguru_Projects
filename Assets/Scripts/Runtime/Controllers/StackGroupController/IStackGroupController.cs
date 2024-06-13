using Assets.Scripts.Runtime.Managers._GameManager;
using Assets.Scripts.Runtime.Zenject.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StackPartGroup;
using Zenject;

public interface IStackGroupController
{
	public StackPartGroup ActiveStackPartGroup { get;  set; }
	void AddNewStackPartGroup();
	void SetActiveStackPartGroup(StackPartGroup stackPartGroup);
	void SplitTheActiveStackPart(SignalOnInputDown signalOnInputDown);
	void ActivateTheStackPart(SignalOnSetActiveStackPart signalOnSetActiveStackPart);
}
