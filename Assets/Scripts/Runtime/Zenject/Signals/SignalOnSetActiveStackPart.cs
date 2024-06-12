using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalOnSetActiveStackPart
{
	public StackPart StackPart;
	public StackPart PreviousStackPart;

	public SignalOnSetActiveStackPart(StackPart stackPart, StackPart previousStackPart)
	{
		StackPart = stackPart;
		PreviousStackPart = previousStackPart;
	}
}
