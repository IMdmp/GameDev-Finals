/*
* Copyright (c) jmkhilario
* https://github.com/littlebassistjm
*/

// THIS SCRIPT/STATE IS FOR TESTING PURPOSES ONLY
using UnityEngine;
using System.Collections;
public class SelectUnitState : BattleState
{
	protected override void OnMove(object sender, InfoEventArgs<Point> e)
	{
		SelectTile(e.info + Pos);
	}

	protected override void OnFire(object sender, InfoEventArgs<int> e)
	{
		GameObject content = owner.CurrentTile.content;
		if (content != null)
		{
			owner.currentUnit = content.GetComponent<Unit>();
			owner.ChangeState<MoveTargetState>();
		}
	}
}