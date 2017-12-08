/*
* Copyright (c) jmkhilario
* https://github.com/littlebassistjm
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CaptureAreaState : BattleState
{

	#region Variables
		List<Tile> tiles;
	#endregion

	#region Unity Methods


	// Use this for initialization

	void Start () {

		

	}

	

	// Update is called once per frame

	void Update () {

		

	}


	#endregion


	public override void Enter()
	{
		base.Enter();
		StartCoroutine("Capture");
	}

	public void Capture()
	{
		for (int i = 0; i < 4; ++i)
		{
		}
		
		owner.ChangeState<SelectUnitState>();
	}

}
