using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainManager : MonoBehaviour {


	public Camera _camera;
	private Transform _cameraTransform;
	private float _meshMaxX;
	public GameObject Player;
	public List<GameObject> mapsInPlay = new List<GameObject>();

	private ObjectPool _objectPool;
	private GameObject _lastItem;

	void Awake()
	{

		Player = GameObject.FindGameObjectWithTag("Player");
		_objectPool = GameObject.Find("Game").GetComponent<ObjectPool>();
		//_camera = Camera.mainCamera;
		_cameraTransform = _camera.transform;

		//generate();
	}

	// Use this for initialization
	void Start () {
		//generate initial floor
		createInitialMaps ();


	}


	// Update is called once per frame
	void Update () {
		//Debug.Log("mapsInPlay :"+mapsInPlay.Count);
		var cameraMaxX = _cameraTransform.position.x + _camera.orthographicSize * 2;

		/*if( cameraMaxX > _meshMaxX)
		{
			_meshMaxX +=3500;
		}*/
	
	}

	public void createInitialMaps()
	{
		Vector3 pos;
		for (int i = -1; i < 2; i++) 
		{
			pos = new Vector3(0, 0, i * 30f);

			GameObject go = Instantiate(Resources.Load("Map1")) as GameObject;
			//GameObject go = _objectPool.GetObjectForType("Map1", false);
			go.transform.position = pos;
			mapsInPlay.Add (go);	
			_lastItem = go;
		}
	}

	public void generate()
	{
		Vector3 pos;
		if(_lastItem != null)
			pos = new Vector3(_lastItem.transform.position.x, _lastItem.transform.position.x, _lastItem.transform.position.z + 30f);
		else
			pos = Vector3.zero;

		GameObject go = Instantiate(Resources.Load("Map2")) as GameObject;
		//GameObject go = _objectPool.GetObjectForType("Map1", false);
		go.transform.position = pos;
		mapsInPlay.Add (go);
		_lastItem = go;
	
		Debug.Log("mapsInPlay"+mapsInPlay.Count);
	}

	public void removeMap()
	{
		//Debug.Log("removeMap");
		//if (mapsInPlay.Count > 2) 
		//{				
			//Destroy (mapsInPlay [0]);
			GameObject go = mapsInPlay[0];
			go.GetComponent<MapItem>().hasCollided = false;
			mapsInPlay.RemoveAt(0);
		//mapsInPlay.Remove(go);
			Destroy(go);
			//_objectPool.PoolObject(mapsInPlay [0]);

		//}
		
		
	}

}
