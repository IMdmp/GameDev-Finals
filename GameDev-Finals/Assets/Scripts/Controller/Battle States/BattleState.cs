/*
* Copyright (c) jmkhilario
* https://github.com/littlebassistjm
*/
using UnityEngine;
using System.Collections;



public abstract class BattleState : State {


	#region Variables
		protected BattleController owner;
		public CameraRig cameraRig { get { return owner.cameraRig; } }
		public Board board { get { return owner.board; } }
		public LevelData levelData { get { return owner.levelData; } }
		public Transform tileSelectionIndicator { get { return owner.tileSelectionIndicator; } }
		public Point pos { get { return owner.pos; } set { owner.pos = value; } }
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
		if (pos == p || !board.tiles.ContainsKey(p))
			return;
		pos = p;
		tileSelectionIndicator.localPosition = board.tiles[p].center;
	}
}
