/*
* Copyright (c) jmkhilario
* https://github.com/littlebassistjm
*/
using UnityEngine;



public abstract class State : MonoBehaviour {


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

	public virtual void Enter()
	{
		AddListeners();
	}

	public virtual void Exit()
	{
		RemoveListeners();
	}
	protected virtual void OnDestroy()
	{
		RemoveListeners();
	}
	protected virtual void AddListeners()
	{
	}

	protected virtual void RemoveListeners()
	{
	}
}
