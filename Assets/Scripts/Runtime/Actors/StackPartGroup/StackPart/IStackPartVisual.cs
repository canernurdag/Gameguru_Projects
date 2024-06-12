using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStackPartVisual 
{
	public MeshRenderer MeshRenderer { get; set; }
	float GetCurrentWidth();

	void SetMaterial(Material material);
}
