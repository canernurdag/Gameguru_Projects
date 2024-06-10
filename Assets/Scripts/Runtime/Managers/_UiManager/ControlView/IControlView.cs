using Assets.Scripts.Runtime.Managers._UiManager._View._View.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers._UiManager.ControlView
{
	public interface IControlView
	{
		void ShowView(ViewBase viewBase);
		void HideView(ViewBase viewBase);
	}
}