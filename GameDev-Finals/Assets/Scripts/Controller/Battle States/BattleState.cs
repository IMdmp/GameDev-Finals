/*
* Copyright (c) jmkhilario
* https://github.com/littlebassistjm
*/
using UnityEngine;
using System.Collections.Generic;



public abstract class BattleState : State {


	#region Variables
		protected BattleController owner;
		public CameraRig CameraRig { get { return owner.cameraRig; } }
		public Board Board { get { return owner.board; } }
		public LevelData LevelData { get { return owner.levelData; } }
		public Transform TileSelectionIndicator { get { return owner.tileSelectionIndicator; } }
		public Point Pos { get { return owner.pos; } set { owner.pos = value; } }
		public Turn turn { get { return owner.turn; } }
		public List<Unit> units { get { return owner.units; } }
	#endregion

	#region Unity Methods

	// gets called before Start()
	protected virtual void Awake()
	{
		owner = GetComponent<BattleController>();
	}


	// Use this for initialization

	void Start () {

		

	}

	

	// Update is called once per frame

	void Update () {

		

	}


	#endregion

	protected override void AddListeners()
	{
		InputController.moveEvent += OnMove;
		InputController.fireEvent += OnFire;
	}

	protected override void RemoveListeners()
	{
		InputController.moveEvent -= OnMove;
		InputController.fireEvent -= OnFire;
	}
	protected virtual void OnMove(object sender, InfoEventArgs<Point> e)
	{

	}

	protected virtual void OnFire(object sender, InfoEventArgs<int> e)
	{

	}
	protected virtual void SelectTile(Point p)
	{
		if (Pos == p || !Board.tiles.ContainsKey(p))
			return;
		Pos = p;
		TileSelectionIndicator.localPosition = Board.tiles[p].center;
	}
}
