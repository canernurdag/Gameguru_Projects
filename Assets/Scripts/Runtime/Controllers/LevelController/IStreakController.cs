using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStreakController 
{
	public int StreakCount { get; set; }
	void SetStreakCount(int count);
	void IncreaseStreakCount(SignalOnStreakIncrease signalOnStreakIncrease);
	void ResetStreakCount(SignalOnStreakBreak signalOnStreakBreak);
}
