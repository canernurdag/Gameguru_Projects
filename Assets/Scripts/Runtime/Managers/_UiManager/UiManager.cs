using Assets.Scripts.Runtime.Managers._UiManager.ControlCanvas;
using Assets.Scripts.Runtime.Managers._UiManager.ControlView;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.Managers._UiManager
{
	public class UiManager : MonoBehaviour
	{
		public IControlCanvas ControlCanvas { get; private set; }
		public IControlView ConrolView { get; private set; }


		[Inject]
		public void Construct(IControlCanvas controlCanvas, IControlView controlView)
		{
			ControlCanvas = controlCanvas;
			ConrolView = controlView;
		}


	}
}