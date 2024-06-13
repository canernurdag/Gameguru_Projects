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
		#region DI REF
		public IControlCanvas ControlCanvas { get; private set; }
		public IControlView ControlView { get; private set; }
		#endregion

		#region DIRECT REF
		[SerializeField] private ViewLevelResult _successView, _failView;
		#endregion

		[Inject]
		public void Construct(IControlCanvas controlCanvas, IControlView controlView)
		{
			ControlCanvas = controlCanvas;
			ControlView = controlView;
		}

		public void ActivateSuccessUi(SignalOnLevelSucess signalOnLevelSucess)
		{
			ControlView.ShowView(_successView);
		}

		public void ActivateFailUi(SignalOnLevelFail signalOnLevelFail) 
		{
			ControlView.ShowView(_failView);
		}

		public void CloseSuccessAndFailUi(SignalOnSetActiveStackPart signalOnSetActiveStackPart)
		{
			ControlView.HideView(_successView);
			ControlView.HideView(_failView);
		}
	}
}