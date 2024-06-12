using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultStackPartVisual : MonoBehaviour, IStackPartVisual
{
	[field: SerializeField] public MeshRenderer MeshRenderer { get; set; }

	public float GetCurrentWidth()
	{
		return MeshRenderer.bounds.size.x; ;
	}

	public void SetMaterial(Material material)
	{
		MeshRenderer.material = material;
	}


}
