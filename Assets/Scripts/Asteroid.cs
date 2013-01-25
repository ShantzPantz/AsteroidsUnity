using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	public GameObject asteroidPrefab;
	
	public int maxSpeed;
	public int minSpeed;
	
	public int maxRotationSpeed;
	public int minRotationSpeed;
	
	public float scaleVariance;
	
	void Start () {
		// Set initial movement
		int xForce = Random.Range(minSpeed, maxSpeed);
		int zForce = Random.Range(minSpeed, maxSpeed);
		
		if( Random.value > 0.5 )
			xForce *= -1;
		
		if( Random.value > 0.5 )
			zForce *= -1;
		
		// Set initial rotation movement
		int rotationX = Random.Range(minRotationSpeed, maxRotationSpeed);
		int rotationY = Random.Range(minRotationSpeed, maxRotationSpeed);
		
		rigidbody.AddTorque(new Vector3(rotationX, rotationY, 0));
		
		Vector3 force = new Vector3(xForce, 0, zForce);		
		rigidbody.AddForce(force);
		
		float randScale = Random.Range(0, scaleVariance);
		transform.localScale += new Vector3(randScale, randScale, randScale);
	}
	
	
	void OnCollisionEnter(Collision collision) {
		
		// Instantiate new child astroids
		
		
		if( collision.gameObject.name == "defaultBullet" )
		{
			Destroy (collision.gameObject);
			
			for(int i = 0; i<3; i++) {
				GameObject chunk = Instantiate(asteroidPrefab, transform.position, transform.rotation) as GameObject;
			}
			
			Destroy(this.gameObject);
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}

}
