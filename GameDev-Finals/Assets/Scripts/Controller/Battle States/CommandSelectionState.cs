using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CommandSelectionState : BaseAbilityMenuState
{
	protected override void Confirm()
	{
		owner.ChangeState<MoveTargetState>();
	
	}

	protected override void Cancel()
	{
		owner.ChangeState<ExploreState>();
	}
}