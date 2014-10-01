using UnityEngine;
using System.Collections;

public class CameraFollowCar : MonoBehaviour {


	public Transform cameraTarget;
	// Use this for initialization
	void Awake()
	{

	}

	void Start () {
	
	}


	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (5, 5, cameraTarget.position.z-4);
	}
}
