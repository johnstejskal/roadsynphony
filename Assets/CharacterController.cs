using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	private int speed = 10;

	public bool buttonState = false;	
	public Rect button  = new Rect(75,20,100,55); //holds actual button rect coordinates
	public Rect initialPosition = new Rect(75,20,100,55); //holds starting rect coordinates
	public Rect activePosition = new Rect(75,130,100,55);
	private bool _isMoving;

	private TerrainManager _mapGenerator;


 //holds ending rect coordinates

	// Use this for initialization
	void Start () {
		_isMoving = false;
		_mapGenerator = GameObject.FindGameObjectWithTag("CodeObject").GetComponent<TerrainManager>();
	}



	// Update is called once per frame
	void Update() {






		//transform.position = new Vector3(0,0,transform.position.z * (speed * Time.deltaTime)).Normalize();
		transform.position += transform.forward * speed * Time.deltaTime;
		if (Input.GetKey("left"))
		{ 
			if(!_isMoving)
			{
				_isMoving = true;
				iTween.MoveBy(gameObject,iTween.Hash(
				"x"   , -2,
				"time", 0.2f,
				"easetype","easeInOutCubic",
				"oncomplete","moveComplete"
				));

			}
		}
			
			//rigidbody.MovePosition(rigidbody.position - speed * Time.deltaTime);

		if (Input.GetKey("right"))
		{
			if(!_isMoving)
			{
				_isMoving = true;
				iTween.MoveBy(gameObject,iTween.Hash(
				"x"   , 2,
				"time", 0.2f,
				"easetype","easeInOutCubic",
				"oncomplete","moveComplete"
				));

			}
		}
        
        
	}
	void moveComplete()
	{
		_isMoving = false;
	}

	void MoveButton(Rect newCoordinates){
		button=newCoordinates;
	}


	void FixedUpdate() {

	}

	void foo()
	{

	}
	


	

}
