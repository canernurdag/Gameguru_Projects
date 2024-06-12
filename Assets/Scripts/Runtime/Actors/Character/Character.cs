using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Character : MonoBehaviour
{
    public class CharacterFactory : PlaceholderFactory<Character>
	{

	}

	public IAnimatorController CharacterAnimatorController { get; private set; }
	public ICharacterMovement CharacterMovement { get; private set; }

	[Inject]
	public void Construct(IAnimatorController animatorController, ICharacterMovement characterMovement)
	{
		CharacterAnimatorController = animatorController;
		CharacterMovement = characterMovement;
	}
}
