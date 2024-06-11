using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class GridSlotSelector : MonoBehaviour, ISelector
{
	[SerializeField] private GridSlot _gridSlot;
	[SerializeField] private GridSlotVisualChanger _gridSlotVisualChanger;

	[SerializeField]private GridController _gridController;

	[Inject]
	public void Construct(GridController gridController)
	{
		_gridController = gridController;
	}

	private void OnMouseDown()
	{
		if(_gridSlot.IsFull)
		{
			Deselect();
		}
		else if(!_gridSlot.IsFull)
		{
			Select();
		}
	}

	public void Deselect()
	{
		_gridSlot.SetIsFull(false);
		_gridSlotVisualChanger.SetActivenessOfForeGroundImageGo(false);
	}

	public void Select()
	{
		_gridSlot.SetIsFull(true);
		_gridSlotVisualChanger.SetActivenessOfForeGroundImageGo(true);

		_gridController.ExecuteMatches(_gridSlot);
	}

	#region EDITOR
	public void SetGridControllerEditor()
	{
		_gridController = FindObjectOfType<GridController>();
	}
	#endregion

}
