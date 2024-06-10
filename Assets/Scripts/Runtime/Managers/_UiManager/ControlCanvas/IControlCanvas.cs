using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers._UiManager.ControlCanvas
{
	public interface IControlCanvas
	{
		List<CanvasBase> Canvases { get; set; }
		void ShowCanvas(CanvasBase canvasBase);
		void HideCanvas(CanvasBase canvasBase);

		void HideAllCanvases();
	}
}