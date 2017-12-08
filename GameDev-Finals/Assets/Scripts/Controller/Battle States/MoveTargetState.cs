/*
* Copyright (c) jmkhilario
* https://github.com/littlebassistjm
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveTargetState : BattleState {


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
		Movement mover = turn.actor.GetComponent<Movement>();
		tiles = mover.GetTilesInRange(Board);
		Board.SelectTiles(tiles);
	}

	public override void Exit()
	{
		base.Exit();
		Board.DeSelectTiles(tiles);
		tiles = null;
	}

	protected override void OnMove(object sender, InfoEventArgs<Point> e)
	{
		SelectTile(e.info + Pos);
	}

	protected override void OnFire(object sender, InfoEventArgs<int> e)
	{
		if (tiles.Contains(owner.CurrentTile))
			owner.ChangeState<MoveSequenceState>();
	}
}
