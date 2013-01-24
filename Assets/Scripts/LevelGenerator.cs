using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {
	public GameObject asteroid;
	public int numAsteroids;
	public float maxScale = 2.0F;
	public float minScale = 0.1F;
	
	private Vector2 _wrap;
	private Vector2 _wrapMax;
	
	void Awake() {
		Vector3 wrapMin = Camera.main.ScreenToWorldPoint(new Vector3(0,0,Camera.main.transform.position.y));
		_wrap = new Vector2(wrapMin.x-4, wrapMin.z-4);
		
		Vector3 wrapMax = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.y));
		_wrapMax = new Vector2(wrapMax.x+4, wrapMax.z+4);
	}
	
	// Use this for initialization
	void Start () {
		for( int i = 0; i < numAsteroids; i++ ) {
			Vector3 pos = new Vector3(Random.Range(_wrap.x, _wrapMax.x), 0, Random.Range(_wrap.y, _wrapMax.y));
			Instantiate(asteroid, pos, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
