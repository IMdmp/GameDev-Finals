/*
* Copyright (c) jmkhilario
* https://github.com/littlebassistjm
*/
using UnityEngine;



public class CameraRig : MonoBehaviour {


	#region Variables
		public float speed = 3f;
		public Transform follow;
		Transform _transform;
	#endregion

	#region Unity Methods


	// Use this for initialization

	void Start () {

		

	}


	void Awake()
	{
		_transform = transform;
	}

	void Update()
	{
		if (follow)
			_transform.position = Vector3.Lerp(_transform.position, follow.position, speed * Time.deltaTime);
	}


	#endregion

}
