using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers._UiManager._View._View.Abstract
{
	public abstract class ViewBase : MonoBehaviour
	{
		public abstract void Initialize();
		public abstract void Show();
		public abstract void Hide();
	}
}