/*
* Copyright (c) jmkhilario
* https://github.com/littlebassistjm
*/
using UnityEngine;
using System.Collections.Generic;
using System;

public class Board : MonoBehaviour {


	#region Variables
		[SerializeField] GameObject tilePrefab;
		public Dictionary<Point, Tile> tiles = new Dictionary<Point, Tile>();

		Point[] dirs = new Point[4] 
		{
		  new Point(0, 1), // north
		  new Point(0, -1), // south
		  new Point(1, 0), // east
		  new Point(-1, 0) // west
		};

		Color selectedTileColor = new Color(0, 1, 1, 1);
		Color defaultTileColor = new Color(1, 1, 1, 1);
		Color prevTileColor;

		public Material allyTerritoryMaterial;
		public Material enemyTerritoryMaterial;
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

	public List<Tile> Search(Tile start, Func<Tile, Tile, bool> addTile)
	{
		List<Tile> retValue = new List<Tile>();
		retValue.Add(start);

		ClearSearch();
		Queue<Tile> checkNext = new Queue<Tile>();
		Queue<Tile> checkNow = new Queue<Tile>();

		start.distance = 0;
		checkNow.Enqueue(start); // Enqueue == add to queue

		while (checkNow.Count > 0)
		{
			Tile t = checkNow.Dequeue();

			// gets the Tiles from each direction of the currently selected Tile
			for (int i = 0; i < 4; ++i)
			{
				Tile next = GetTile(t.pos + dirs[i]);
				if (next == null || next.distance <= t.distance + 1) // did we get a tile? is it going to that tile from this tile shorter than via other tiles?
					continue; // skip current iteration
				if (addTile(t, next))
				{
					next.distance = t.distance + 1;
					next.prev = t;
					checkNext.Enqueue(next);
					retValue.Add(next);
				}
			}
			if (checkNow.Count == 0)
				SwapReference(ref checkNow, ref checkNext);
		}

		return retValue;
	}

	// used to clear the pathfinding values of each Tile each time a new search is to be done;
	void ClearSearch()
	{
		foreach (Tile t in tiles.Values)
		{
			t.prev = null;
			t.distance = int.MaxValue;
		}
	}

	// get Tile at Point/coordinate p
	public Tile GetTile(Point p)
	{
		return tiles.ContainsKey(p) ? tiles[p] : null;
	}

	// swap 
	void SwapReference(ref Queue<Tile> a, ref Queue<Tile> b)
	{
		Queue<Tile> temp = a;
		a = b;
		b = temp;
	}

	// For highlighting and un-highlighting Tiles, respectively
	public void SelectTiles(List<Tile> tiles)
	{
		for (int i = tiles.Count - 1; i >= 0; --i)
			tiles[i].GetComponent<Renderer>().material.SetColor("_Color", selectedTileColor);
	}
	public void DeSelectTiles(List<Tile> tiles)
	{
		for (int i = tiles.Count - 1; i >= 0; --i)
		{
			if (tiles[i].faction == "ally")
			{
				tiles[i].GetComponent<Renderer>().material = allyTerritoryMaterial;
			}
			else if (tiles[i].faction == "enemy")
			{
				tiles[i].GetComponent<Renderer>().material = enemyTerritoryMaterial;
			}
			else
			{
				tiles[i].GetComponent<Renderer>().material.SetColor("_Color", defaultTileColor);
			}

		}
	}

	public void CaptureTile(Tile firstTile, string faction)
	{
		List<Tile> capturedTiles = new List<Tile>();
		capturedTiles.Add(firstTile);

		// gets the Tiles from each direction of the currently captured Tile
		for (int i = 0; i < 4; ++i)
		{
			Tile next = GetTile(firstTile.pos + dirs[i]);
			capturedTiles.Add(next);

		}
		for(int i = 0; i < capturedTiles.Count; i++)
		{
			if (capturedTiles[i] != null)
			{
				capturedTiles[i].faction = faction;
				if (faction == "ally")
				{
					capturedTiles[i].GetComponent<Renderer>().material = allyTerritoryMaterial;
				}
				else if (faction == "enemy")
				{
					capturedTiles[i].GetComponent<Renderer>().material = enemyTerritoryMaterial;
				} 
			}
		}
	}
}
