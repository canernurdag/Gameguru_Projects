using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimatorController
{
	public Animator Animator { get; set; }
	void SetAnimatorActiveness(bool value);
	void SetCurrentAnimatorStateAndPlayImmediately(string stateName, int layerNo, float normalizedTime);
	void SetCurrentAnimatorState(string stateName);
	void SetCurrentAnimatorState(string stateName, bool boolValue);
	void SetAnimatorLayerWeight(int layerIndex, float layerWeight);
	void SetAnimatorLayerWeight(int layerIndex, float layerWeight, float duration);
	void SetFloatParameter(string floatName, float value);
	void SetFloatParameter(string floatName, float value, float duration);
	string Idle { get; set; }
	string Run { get; set; }
	string Dance { get; set; }
}
