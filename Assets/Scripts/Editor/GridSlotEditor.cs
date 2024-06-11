using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridSlot))]
public class GridSlotEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();	
		serializedObject.ApplyModifiedProperties();

	}
}
