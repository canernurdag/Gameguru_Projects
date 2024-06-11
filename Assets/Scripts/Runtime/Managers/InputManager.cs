using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputManager : MonoBehaviour
{
	private SignalBus _signalBus;

	[Inject]
	public void Construct(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_signalBus.Fire(new SignalOnInputDown());
		}
	}
}
