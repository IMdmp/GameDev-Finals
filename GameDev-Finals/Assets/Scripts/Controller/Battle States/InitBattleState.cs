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

	// TODO : Uncomment alt + k + u
	//IEnumerator Init()
	//{
	//	board.Load(levelData);
	//	Point p = new Point((int)levelData.tiles[0].x, (int)levelData.tiles[0].z);
	//	SelectTile(p);
	//	yield return null;
	//	owner.ChangeState<MoveTargetState>();
	//}

	#region remove
	IEnumerator Init()
	{
		Board.Load(LevelData);
		Point p = new Point((int)LevelData.tiles[0].x, (int)LevelData.tiles[0].z);
		SelectTile(p);
		SpawnTestUnits(); // This is new
		yield return null;
		owner.ChangeState<SelectUnitState>(); // This is changed
	}
	void SpawnTestUnits()
	{
		System.Type[] components = new System.Type[] { typeof(WalkMovement), typeof(FlyMovement), typeof(TeleportMovement) };
		for (int i = 0; i < 3; ++i)
		{
			GameObject instance = Instantiate(owner.heroPrefab) as GameObject;
			Point p = new Point((int)LevelData.tiles[i].x, (int)LevelData.tiles[i].z);
			Unit unit = instance.GetComponent<Unit>();
			unit.Place(Board.GetTile(p));
			unit.Match();
			Movement m = instance.AddComponent(components[i]) as Movement;
			m.range = 5;
			m.jumpHeight = 1;
		}
	}
#endregion
}
