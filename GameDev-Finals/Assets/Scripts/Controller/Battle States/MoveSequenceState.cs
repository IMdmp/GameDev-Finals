/*
* Copyright (c) jmkhilario
* https://github.com/littlebassistjm
*/
using UnityEngine;
using System.Collections;


public class MoveSequenceState : BattleState {


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
		base.Enter();
		StartCoroutine("Sequence");
	}

	IEnumerator Sequence()
	{
		Movement m = turn.actor.GetComponent<Movement>();
		yield return StartCoroutine(m.Traverse(owner.CurrentTile));
		owner.ChangeState<SelectUnitState>();
	}
}
