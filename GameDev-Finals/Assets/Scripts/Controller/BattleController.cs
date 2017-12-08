/*
* Copyright (c) jmkhilario
* https://github.com/littlebassistjm
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BattleController : StateMachine {


	#region Variables
		public CameraRig cameraRig;
		public Board board;
		public LevelData levelData;
		public Transform tileSelectionIndicator;
		public Point pos;

		public AbilityMenuPanelController abilityMenuPanelController;
		public Turn turn = new Turn();
		public List<Unit> units = new List<Unit>();

	#region remove
	public GameObject heroPrefab;
			public Tile CurrentTile { get { return board.GetTile(pos); } }
		#endregion
	#endregion

	#region Unity Methods


	// Use this for initialization

	void Start()
	{
		ChangeState<InitBattleState>();
	}



	// Update is called once per frame

	void Update () {

		

	}


	#endregion
}
