using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGridCreator
{
	void CreateGrid(int dimensionCount);
	void DestroyGrid();
	int DimensionCount { get; set; }
	GridSlot[,] Grid { get; set; }
}
