using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UiGridController : MonoBehaviour
{
	#region DIRECT REF
	[SerializeField] private Button _rebuildButton;
	[SerializeField] private TMP_Text _matchCount;
	[SerializeField] private TMP_InputField _dimensionCount;
	#endregion

	#region DI REF
	private SignalBus _signalBus;
	#endregion

	[Inject]
	public void Constrcut(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	private void Start()
	{
		_rebuildButton.onClick.AddListener(() =>
		{
			var dimensionCount = GetDimensionCount();
			_signalBus.Fire(new SignalGridRebuild(dimensionCount));
		});
	}

	public void SetMatchCount(SignalMatchCountChanged signalMatchCountChanged)
	{
		_matchCount.text = $"Match Count: {signalMatchCountChanged.MatchCount}";
	}

	private int GetDimensionCount()
	{
		var count = int.Parse(_dimensionCount.text);
		return count;
	}


}
