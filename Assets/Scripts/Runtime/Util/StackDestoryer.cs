using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackDestoryer : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		var stackPart = other.GetComponent<StackPart>();
		if (stackPart == null) return;

		stackPart.gameObject.SetActive(false);
	}
}
