/*
* Copyright (c) jmkhilario
* https://github.com/littlebassistjm
*/
using UnityEngine;
using System.Collections;


public class InitBattleState : BattleState {


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

	public override void Enter()
	{
		base.Enter(); // equivalent to super() in java
		StartCoroutine(Init()); // used to wait one frame since Enter() and Exit() are called during transitions and we can't change state during a transition
	}
	IEnumerator Init()
	{
		board.Load(levelData);
		Point p = new Point((int)levelData.tiles[0].x, (int)levelData.tiles[0].z);
		SelectTile(p);
		yield return null;
		owner.ChangeState<MoveTargetState>();
	}
}
