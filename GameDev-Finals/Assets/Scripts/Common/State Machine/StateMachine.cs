/*
* Copyright (c) jmkhilario
* https://github.com/littlebassistjm
*/
using UnityEngine;
using System.Collections;

// used to maintain reference to current state and handle switching of states
public class StateMachine : MonoBehaviour {


	#region Variables
		protected State _currentState;
		protected bool _inTransition;
	#endregion

	#region Unity Methods


	// Use this for initialization

	void Start () {

		

	}

	

	// Update is called once per frame

	void Update () {

		

	}


	#endregion

	public virtual State CurrentState
	{
		get { return _currentState; }
		set { Transition(value); }
	}
	public virtual T GetState<T>() where T : State
	{
		T target = GetComponent<T>();
		if (target == null)
			target = gameObject.AddComponent<T>();
		return target;
	}

	public virtual void ChangeState<T>() where T : State
	{
		CurrentState = GetState<T>();
	}
	protected virtual void Transition(State value)
	{
		if (_currentState == value || _inTransition) 
			return;
		_inTransition = true;

		if (_currentState != null)
			_currentState.Exit();

		_currentState = value;

		if (_currentState != null)
			_currentState.Enter();

		_inTransition = false;
	}
}
