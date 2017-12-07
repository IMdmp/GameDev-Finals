using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController : MonoBehaviour {

	Repeater _hor = new Repeater("Horizontal");
	Repeater _ver = new Repeater("Vertical");

	public static event EventHandler<InfoEventArgs<Point>> moveEvent; // directions
	public static event EventHandler<InfoEventArgs<int>> fireEvent; // actions

	string[] _buttons = new string[] {"Fire1", "Fire2", "Fire3"}; // action buttons we want to check


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int x = _hor.Update();
		int y = _ver.Update();
		if (x != 0 || y != 0) // checks for movement
		{
			if (moveEvent != null)
				moveEvent(this, new InfoEventArgs<Point>(new Point(x, y)));
		}

		for (int i = 0; i < 3; ++i) // checks for actions
		{
			if (Input.GetButtonUp(_buttons[i])) // on release of the button
			{
				if (fireEvent != null)
					fireEvent(this, new InfoEventArgs<int>(i));
			}
		}
	}

}

class Repeater
{
	const float threshold = 0.5f; // amount of time a button is pressed before we will consider as a hold
	const float rate = 0.25f; // speed at which the held button's action will repeat
	float _next; // target point in time that must be passed before new events will be registered
	bool _hold; // is a button being held down?
	string _axis; // will store the axis/direction the user is pressing 
	public Repeater (string axisName)
	{
		_axis = axisName;
	}
	public int Update ()
	{
		int retValue = 0;
		int value = Mathf.RoundToInt( Input.GetAxisRaw(_axis) ); // get the direction the user is pressing: -1, 0, or 1 of horizontal or vertical; GetAxis() gives float values from -1 to 1 in increasing/decreasing manner
		if (value != 0) // is there user input?
		{
			if (Time.time > _next) // has sufficient time passed to allow a hold event?
			{
				retValue = value;
				_next = Time.time + (_hold ? rate : threshold);
				_hold = true;
			}
		}
		else // reset the values if no button is being pressed
		{
			_hold = false;
			_next = 0;
		}
		return retValue;
	}
}
