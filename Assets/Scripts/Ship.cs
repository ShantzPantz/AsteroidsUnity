using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	
	public int thrust;
	public float rotationSpeed;
	public ParticleSystem thrustPS;
	
	public int bulletSpeed;
	public GameObject bulletPrefab;
	
	public float maxThrustVolume;
	public float minThrustVolume;
	
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
			// Turn On Trhust Particles
			thrustPS.Play();
			
			// Handle Thrust Sound
			if( !audio.isPlaying )
				audio.Play();
			
			audio.volume = maxThrustVolume;
			
			// Add Thrust Force
			Vector3 power = transform.forward * Time.deltaTime * thrust;
			rigidbody.AddForce(power);
		}
		else{
			thrustPS.Stop();
			
			if( audio.isPlaying )
				audio.volume = minThrustVolume;
		}
		
		if( Input.GetButtonDown("Jump") ){
			// Create Bullet
			GameObject gun = GameObject.Find("Gun");
			GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, transform.rotation) as GameObject;
			bullet.name = "defaultBullet";
			Physics.IgnoreCollision(bullet.collider, collider);
			bullet.rigidbody.AddRelativeForce(Vector3.forward * bulletSpeed);
			
			if( gun.audio.isPlaying ){
				gun.audio.Stop();
			}
			gun.audio.Play();
		}
	}
}
