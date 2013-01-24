using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	
	public int thrust;
	public float rotationSpeed;
	public ParticleSystem thrustPS;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// is horizontal
		float rotation = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
		// Is pressing up
		bool powerOn = Input.GetButton("Vertical");
		transform.Rotate(0, rotation, 0);
		
		if(powerOn){
			thrustPS.Play();
			
			Vector3 power = transform.forward * Time.deltaTime * thrust;
			rigidbody.AddForce(power);
		}
		else{
			thrustPS.Stop();
				
		}
	}
}
