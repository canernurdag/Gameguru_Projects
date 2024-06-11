using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

public class GridSlot : MonoBehaviour
{
	public class GridSlotFactory: PlaceholderFactory<GridSlot>
	{

	}

	//[field: SerializeField] => For Saving Data In Editor purpose
	[field: SerializeField] public int RowIndex { get; private set; }
	[field: SerializeField] public int ColumnIndex { get; private set; }


	//[field: SerializeField] => Direct Reference in Prefab
	[field: SerializeField] public BoxCollider Collider { get; private set; }
	[field: SerializeField] public GridSlotSelector Selector { get; private set; }
	[field: SerializeField] public GridSlotVisualChanger VisualChange { get; private set; }
	public bool IsFull { get; private set; } = false;
	public bool IsChecked { get; private set; } = false;

	public void SetIsFull(bool isFull)
	{
		IsFull = isFull;
		VisualChange.SetActivenessOfForeGroundImageGo(isFull);

	}

	public void SetIndexes(int rowIndex, int columnIndex)
	{
		RowIndex = rowIndex;
		ColumnIndex = columnIndex;
	}

	public void SetIsChecked(bool isChecked)
	{
		IsChecked = isChecked;
	}
	
	

}
