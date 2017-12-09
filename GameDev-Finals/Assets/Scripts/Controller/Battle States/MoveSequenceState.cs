/*
* Copyright (c) jmkhilario
* https://github.com/littlebassistjm
*/
using UnityEngine.SceneManagement;
using System.Collections;


public class MoveSequenceState : BattleState {


	#region Variables
	int dominance;
	Unit winner;
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
		Movement m = owner.turn.actor.GetComponent<Movement>();
		yield return StartCoroutine(m.Traverse(owner.CurrentTile));
		dominance = Board.CaptureTile(owner.CurrentTile, owner.turn.actor.faction);

		if (dominance >= 70)
		{
			string winner = Board.GetVictor();
			// go to VictoryState; pass winner
			SceneManager.LoadScene("VictoryScene");
		}

		turn.hasUnitMoved = true;
		owner.ChangeState<SelectUnitState>();
	}
}
