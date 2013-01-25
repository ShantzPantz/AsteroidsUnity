using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	
	public int thrust;
	public float rotationSpeed;
	public ParticleSystem thrustPS;
	
	public int bulletSpeed;
	public GameObject bulletPrefab;
	
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
		
		if( Input.GetButtonDown("Jump") ){
			// Create Bullet
			GameObject bullet = Instantiate(bulletPrefab, transform.Find("Gun").position, transform.rotation) as GameObject;
			bullet.name = "defaultBullet";
			Physics.IgnoreCollision(bullet.collider, collider);
			bullet.rigidbody.AddRelativeForce(Vector3.forward * bulletSpeed);
		}
	}
}
