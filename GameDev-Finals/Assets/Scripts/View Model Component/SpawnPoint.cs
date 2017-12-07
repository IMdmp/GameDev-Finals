using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

	public const float stepHeight = 0.25f;
	public Point pos;
	public int height;
	public string faction;


	public void Load (Point p, string faction, int h)
	{
		pos = p;
		this.faction = faction;
		transform.localPosition = new Vector3( pos.x, height * stepHeight / 2f, pos.y );
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
