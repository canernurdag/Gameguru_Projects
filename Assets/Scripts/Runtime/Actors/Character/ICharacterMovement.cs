using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterMovement
{
	void Move(Vector3 targetPos, Action callback);
}
