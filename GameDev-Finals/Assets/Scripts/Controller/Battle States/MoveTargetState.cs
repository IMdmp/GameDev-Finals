/*
* Copyright (c) jmkhilario
* https://github.com/littlebassistjm
*/
using UnityEngine;
using System.Collections;


public class MoveTargetState : BattleState {


	#region Variables
	#endregion

	#region Unity Methods


	// Use this for initialization

	void Start () {

		

	}

	

	// Update is called once per frame

	void Update () {

		

	}


	#endregion

	protected override void OnMove(object sender, InfoEventArgs<Point> e)
	{
		SelectTile(e.info + pos);
	}
}
