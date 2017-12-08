/*
* Copyright (c) jmkhilario
* https://github.com/littlebassistjm
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Board : MonoBehaviour {


	#region Variables
		[SerializeField] GameObject tilePrefab;
		public Dictionary<Point, Tile> tiles = new Dictionary<Point, Tile>();
	#endregion

	#region Unity Methods


	// Use this for initialization

	void Start () {

		

	}

	

	// Update is called once per frame

	void Update () {

		

	}


	#endregion

	public void Load(LevelData data)
	{
		for (int i = 0; i < data.tiles.Count; ++i)
		{
			GameObject instance = Instantiate(tilePrefab) as GameObject;
			Tile t = instance.GetComponent<Tile>();
			t.Load(data.tiles[i]);
			tiles.Add(t.pos, t);
		}
	}
}
