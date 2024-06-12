using Assets.Scripts.Runtime.Controllers._AnimatorController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorController : AnimatorController, IAnimatorController
{
	public override string Idle { get; set; } = "Idle";
	public override string Run { get; set; } = "Run";
	public override string Dance { get; set; } = "Dance";
}
