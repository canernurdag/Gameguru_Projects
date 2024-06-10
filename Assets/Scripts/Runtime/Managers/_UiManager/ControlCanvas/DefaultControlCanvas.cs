using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.Managers._UiManager.ControlCanvas
{
	public class DefaultControlCanvas : MonoBehaviour, IControlCanvas
	{
		public List<CanvasBase> Canvases { get; set; } = new();

		[Inject]
		public void Construct(CanvasBase[] canvases)
		{
			Canvases = canvases.ToList();
		}


		public void HideCanvas(CanvasBase canvasBase)
		{
			canvasBase.gameObject.SetActive(false);
		}

		public void ShowCanvas(CanvasBase canvasBase)
		{
			canvasBase.gameObject.SetActive(true);
		}


		public void HideAllCanvases()
		{
			Canvases.ForEach(x => HideCanvas(x));
		}
	}
}