using System.Collections;
using System.Collections.Generic;
using _MyProject.Scripts.Tricol.Controller;
using UnityEngine;

/// <summary>
/// both hand class 
/// </summary>
public class ControllerBoth 
{
	public enum LR
	{
		Left,
		Right,
	}

	public LR MyLR; 
	
	public IOneController Hand {
		get { return _hand; } 
	}
	IOneController _hand ;

	public ControllerBoth(LR lr)
	{
		MyLR = lr; 
		if (MyLR == LR.Left)
		{
			_hand = ControllerUtils.PtrLeftHand; 
		}
		else
		{
			_hand = ControllerUtils.PtrRightHand; 
		}
	}
}
