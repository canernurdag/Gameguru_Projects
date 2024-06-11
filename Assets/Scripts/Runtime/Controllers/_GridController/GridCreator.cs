using Assets.Scripts.Runtime.Managers._CinemachineManager;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditorInternal.VR;
using UnityEngine;
using Zenject;

public class GridCreator : MonoBehaviour, IGridCreator
{
	#region DI REF
	private SignalBus _signalBus;
	private GridSlot.GridSlotFactory _gridSlotFactory;
	private List<GridSlot> _gridSlotsFromEditor = new();
	#endregion

	#region DIRECT REF
	[SerializeField] private GridSlot _gridSlotPrefab;
	#endregion

	#region GRID SLOTS and attributes
	public GridSlot[,] Grid { get; set; }
	private float _gridSlotDimensionLength;
	[field: SerializeField] public int DimensionCount { get; set; }
	#endregion


	[Inject]
	public void Consturct(
		GridSlot.GridSlotFactory gridSlotFactory,
		List<GridSlot> gridSlotsFromEditor,
		SignalBus signalBus)
	{
		_gridSlotFactory = gridSlotFactory;
		_gridSlotsFromEditor = gridSlotsFromEditor;
		_signalBus = signalBus;
	}

	private void Start()
	{
		InitGridTwoDimensionalArrayFromScene();
	}

	private void InitGridTwoDimensionalArrayFromScene()
	{
		bool isGridExistInScene = _gridSlotsFromEditor.Count > 0;

		if (isGridExistInScene)
		{
			Grid = new GridSlot[DimensionCount, DimensionCount];

			for (int i = 0; i < DimensionCount; i++)
			{
				for (int j = 0; j < DimensionCount; j++)
				{
					Grid[i, j] = _gridSlotsFromEditor.First(x => x.RowIndex == i && x.ColumnIndex == j);
				}
			}
		}
	}

	public void CreateGrid(SignalGridRebuild signalGridRebuild)
	{
		CreateGrid(signalGridRebuild.Dimension);
	}

	public void CreateGrid(int dimensionCount)
	{
		if (dimensionCount < 0) return;
		DimensionCount = dimensionCount;

		SetGridSlotDimensionSize();

		DestroyGrid();
		Grid = CreateTwoDimensionalArrayForGrid(dimensionCount);
		Vector3 gridStartPos = GetGridStartPos(dimensionCount);
		CreateGridSlots(dimensionCount, gridStartPos);
	
		_signalBus.Fire(new SignalCameraOthSizeChanged(dimensionCount * _gridSlotDimensionLength));		
	}

	private void CreateGridSlots(int dimensionCount, Vector3 gridStartPos)
	{
		for (int i = 0; i < dimensionCount; i++)
		{
			for (int j = 0; j < dimensionCount; j++)
			{
				GridSlot gridSlot = null;
				gridSlot = _gridSlotFactory.Create();
				
				gridSlot.transform.SetParent(transform);
				gridSlot.SetIndexes(i, j);

				gridSlot.transform.position =
					gridStartPos
					+ Vector3.forward * i * _gridSlotDimensionLength
					+ Vector3.right * j * _gridSlotDimensionLength;

				Grid[i, j] = gridSlot;
			}
		}
	}



	private Vector3 GetGridStartPos(int dimensionCount)
	{
		return Vector3.zero
		- (Vector3.forward * dimensionCount * _gridSlotDimensionLength / 2)
		- (Vector3.right * dimensionCount * _gridSlotDimensionLength / 2);
	}

	public void DestroyGrid()
	{
		if (Grid != null)
		{
			for (int i = 0; i < Grid.GetLength(0); i++)
			{
				for (int j = 0; j < Grid.GetLength(1); j++)
				{
					DestroyImmediate(Grid[i, j].gameObject);
				}
			}
		}
	}

	public void SetGridSlotDimensionSize()
	{
		GridSlot temp = Instantiate(_gridSlotPrefab);
		_gridSlotDimensionLength = temp.GetComponent<BoxCollider>().bounds.size.x;
		DestroyImmediate(temp.gameObject);
	}

	private GridSlot[,] CreateTwoDimensionalArrayForGrid(int dimensionCount)
	{
		return new GridSlot[dimensionCount, dimensionCount];
	
	}


	#region EDITOR
	[ExecuteInEditMode]
	public void CreateGridEditor(int dimensionCount)
	{
		if (dimensionCount < 0) return;
		DimensionCount = dimensionCount;
		SetGridSlotDimensionSize();

		DestroyGrid();
		Grid = CreateTwoDimensionalArrayForGrid(dimensionCount);
		Vector3 gridStartPos = GetGridStartPos(dimensionCount);
		CreateGridSlotsEditor(dimensionCount, gridStartPos);

		var defaultVirtualCameraController = FindObjectOfType<DefaultVirtualCameraController>();
		var vCam = FindObjectOfType<CinemachineVirtualCamera>();
		defaultVirtualCameraController.SetOrthoSize(vCam, dimensionCount * _gridSlotDimensionLength);

	}

	private void CreateGridSlotsEditor(int dimensionCount, Vector3 gridStartPos)
	{
		for (int i = 0; i < dimensionCount; i++)
		{
			for (int j = 0; j < dimensionCount; j++)
			{
				GridSlot gridSlot = null;
				gridSlot = Instantiate(_gridSlotPrefab);
				gridSlot.Selector.SetGridControllerEditor();

				gridSlot.transform.SetParent(transform);
				gridSlot.SetIndexes(i, j);

				gridSlot.transform.position =
					gridStartPos
					+ Vector3.forward * i * _gridSlotDimensionLength
					+ Vector3.right * j * _gridSlotDimensionLength;

				Grid[i, j] = gridSlot;
			}
		}
	}
	#endregion

}
