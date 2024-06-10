using Assets.Scripts.Runtime.Managers._UiManager._View._View.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers._UiManager.ControlView
{
	public class DefaultControlView : MonoBehaviour, IControlView
	{
		public void HideView(ViewBase viewBase)
		{
			viewBase.Hide();
		}

		public void ShowView(ViewBase viewBase)
		{
			viewBase.Show();
		}
	}
}