using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class GridController : MonoBehaviour
{
	private IGridCreator _gridCreator;
	private SignalBus _signalBus;
	private int _matchCount = 0;

	[Inject]
	public void Consturct(IGridCreator gridCreator, SignalBus signalBus)
	{
		_gridCreator = gridCreator;
		_signalBus = signalBus;
	}
	

	public void ExecuteMatches(GridSlot selectedGridSlot)
	{
		//THE MATCH LOGIC: A full GridSlot which has at least 2 full GridSlot neighbour is a match. 

		List<GridSlot> checkList = new(); // GridSlots to be checked with neighbours
		List<GridSlot> matchList = new(); // GridSlots that have a match.
		List<GridSlot> clearList = new(); // In order to avoid multiple checks for an gridSlots

		checkList.Add(selectedGridSlot);
		clearList.Add(selectedGridSlot);

		while(checkList.Count>0)
		{
			var gridSlotToBeChecked = checkList.ElementAt(0);
			gridSlotToBeChecked.SetIsChecked(true);
			checkList.RemoveAt(0);


			int left = gridSlotToBeChecked.ColumnIndex - 1;
			int right = gridSlotToBeChecked.ColumnIndex + 1;

			int down = gridSlotToBeChecked.RowIndex - 1;
			int up = gridSlotToBeChecked.RowIndex + 1;

			List<GridSlot> neighbourGridSlots = new();
			GridSlot leftSlot = null;
			GridSlot rightSlot = null;

			GridSlot upSlot = null;
			GridSlot downSlot = null;

			if (left >= 0)
			{
				leftSlot = _gridCreator.Grid[gridSlotToBeChecked.RowIndex, left];
				neighbourGridSlots.Add(leftSlot);
			}
			if (right < _gridCreator.DimensionCount)
			{
				rightSlot = _gridCreator.Grid[gridSlotToBeChecked.RowIndex, right];
				neighbourGridSlots.Add(rightSlot);
			}
			if (up < _gridCreator.DimensionCount)
			{
				upSlot = _gridCreator.Grid[up, gridSlotToBeChecked.ColumnIndex ];
				neighbourGridSlots.Add(upSlot);
			}
			if (down >= 0)
			{
				downSlot = _gridCreator.Grid[down, gridSlotToBeChecked.ColumnIndex ];
				neighbourGridSlots.Add(downSlot);
			}

			//CHECK IS THERE ANY MATCH
			bool isMatch = neighbourGridSlots.Count(x => x.IsFull) >= 2;

			for (int i = 0; i < neighbourGridSlots.Count; i++)
			{
				var gridSlot = neighbourGridSlots[i];
				if(isMatch && gridSlot.IsFull)
				{
					matchList.Add(gridSlot);
				}

				if (gridSlot.IsFull && !gridSlot.IsChecked)
				{
					checkList.Add(gridSlot);
					clearList.Add(gridSlot);
				}
			}

			//RESET Matched GridSlots - IsFull
			if (matchList.Count > 0)
			{
				_matchCount++;
				_signalBus.Fire(new SignalMatchCountChanged(_matchCount));
				matchList.Distinct();
				matchList.ForEach(x => x.SetIsFull(false));
				gridSlotToBeChecked.SetIsFull(false);
			}

		}
	
		//RESET All GridSlots - IsChecked
		if(clearList.Count > 0)
		{
			clearList.ForEach(x => x.SetIsChecked(false));
			selectedGridSlot.SetIsChecked(false);
		}

	}

}
