/*
* Copyright (c) jmkhilario
* https://github.com/littlebassistjm
*/
using UnityEngine;



public class RectTransformAnchorPositionTweener : Vector3Tweener
{


	#region Variables
	RectTransform rt;
	#endregion

	#region Unity Methods
	protected override void Awake()
	{
		base.Awake();
		rt = transform as RectTransform;
	}

	// Use this for initialization

	void Start () {

		

	}

	

	// Update is called once per frame

	void Update () {

		

	}


	#endregion
	protected override void OnUpdate(object sender, System.EventArgs e)
	{
		base.OnUpdate(sender, e);
		rt.anchoredPosition = currentValue;
	}
}
