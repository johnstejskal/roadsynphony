using UnityEngine;
using System.Collections;

public class MapItem : MonoBehaviour {



	private GameObject player;
	public bool hasCollided = false;
	private TerrainManager _terrainGenerator;
	// Use this for initialization
	private float rand;
	private bool isRemoved = false;
	void Awake()
	{
		rand = Random.value;
		player = GameObject.FindGameObjectWithTag("Player");
		_terrainGenerator = GameObject.FindGameObjectWithTag("CodeObject").GetComponent<TerrainManager>();
	}
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}



	void OnCollisionEnter (Collision col)
	{
		if(hasCollided)
			return;

		if(col.gameObject.tag == "Player")
		{
			hasCollided = true;
			if(_terrainGenerator != null)
			_terrainGenerator.generate();
			//Destroy(col.gameObject);
		}

	}

	void OnCollisionExit (Collision col)
	{
		if(isRemoved)
			return;

		Debug.Log("rand :"+rand);
		if(col.gameObject.tag == "Player")
		{
			isRemoved = true;
			_terrainGenerator.removeMap();
			//Destroy(col.gameObject);
		}
		
	}
}
