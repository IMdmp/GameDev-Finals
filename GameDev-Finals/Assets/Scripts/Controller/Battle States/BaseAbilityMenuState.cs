using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public abstract class BaseAbilityMenuState : BattleState
{
	public override void Enter()
	{
		base.Enter();
		SelectTile(turn.actor.tile.pos);
	}
	public override void Exit()
	{
		base.Exit();
	}
	protected override void OnFire(object sender, InfoEventArgs<int> e)
	{
		if (e.info == 0)
			Confirm();
		else
			Cancel();
	}
	protected override void OnMove(object sender, InfoEventArgs<Point> e)
	{

	}
	protected abstract void Confirm();
	protected abstract void Cancel();
}