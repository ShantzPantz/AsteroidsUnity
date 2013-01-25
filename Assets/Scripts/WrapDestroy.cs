using UnityEngine;
using System.Collections;

public class WrapDestroy : MonoBehaviour {
	
	Vector2 _wrap;
	Vector2 _wrapMax;
	
	void Awake() {
		
		Vector3 wrapMin = Camera.main.ScreenToWorldPoint(new Vector3(0,0,Camera.main.transform.position.y));
		_wrap = new Vector2(wrapMin.x-4, wrapMin.z-4);
		
		Vector3 wrapMax = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.y));
		_wrapMax = new Vector2(wrapMax.x+4, wrapMax.z+4);
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// If Object goes off screen, destroy that shit.
		if( transform.position.x > _wrapMax.x 
			|| transform.position.x < _wrap.x
			|| transform.position.z > _wrapMax.y
			|| transform.position.z < _wrap.y
		){
			Destroy (this.gameObject);
		}
	}
}
