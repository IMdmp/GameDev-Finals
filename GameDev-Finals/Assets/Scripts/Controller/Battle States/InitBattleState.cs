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
		//System.Type[] components = new System.Type[] { typeof(WalkMovement), typeof(FlyMovement), typeof(TeleportMovement) };
		GameObject allyInstance = Instantiate(owner.heroPrefab) as GameObject;
		Point allyStartingPoint = new Point((int)LevelData.tiles[0].x, (int)LevelData.tiles[0].z);
		Unit ally = allyInstance.GetComponent<Unit>();
		ally.faction = "ally";
		ally.Place(Board.GetTile(allyStartingPoint));
		ally.Match();
		Movement allyMovement = allyInstance.AddComponent(typeof(TeleportMovement)) as Movement;
		allyMovement.range = 5;
		allyMovement.jumpHeight = 1;

		GameObject enemyInstance = Instantiate(owner.enemyPrefab) as GameObject;
		Point enemyStartingPoint = new Point((int)LevelData.tiles[99].x, (int)LevelData.tiles[99].z);
		Unit enemy = enemyInstance.GetComponent<Unit>();
		enemy.faction = "enemy";
		enemy.Place(Board.GetTile(enemyStartingPoint));
		enemy.Match();
		Movement enemyMovement = enemyInstance.AddComponent(typeof(TeleportMovement)) as Movement;
		enemyMovement.range = 5;
		enemyMovement.jumpHeight = 1;

	}
#endregion
}
