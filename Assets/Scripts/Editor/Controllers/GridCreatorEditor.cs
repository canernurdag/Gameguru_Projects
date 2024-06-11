using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(GridCreator))]
public class GridCreatorEditor : Editor
{
	private void OnEnable()
	{
		InitGridTwoDimensionalArrayFromScene();
	}

	private void InitGridTwoDimensionalArrayFromScene()
	{
		GridCreator gridCreator = (GridCreator)target;

		var gridSlotsInScene = FindObjectsOfType<GridSlot>().ToList();
		bool isGridExistInScene = gridSlotsInScene.Count > 0;

		if (isGridExistInScene)
		{
			gridCreator.Grid = new GridSlot[gridCreator.DimensionCount, gridCreator.DimensionCount];

			for (int i = 0; i < gridCreator.DimensionCount; i++)
			{
				for (int j = 0; j < gridCreator.DimensionCount; j++)
				{
					gridCreator.Grid[i, j] = gridSlotsInScene.First(x => x.RowIndex == i && x.ColumnIndex == j);
				}
			}
		}
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		GridCreator gridCreator = (GridCreator)target;


		if (GUILayout.Button("Create Grid"))
		{
			gridCreator.CreateGridEditor(gridCreator.DimensionCount);
			EditorSceneManager.MarkSceneDirty(gridCreator.gameObject.scene);
		}

	}
}
