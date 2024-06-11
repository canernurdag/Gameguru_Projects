using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridSlotSelector))]
public class GridSlotSelectorEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		serializedObject.ApplyModifiedProperties();

	}
}
