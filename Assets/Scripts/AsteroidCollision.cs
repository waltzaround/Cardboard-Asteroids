using UnityEngine;
using System.Collections;

public class AsteroidCollision : MonoBehaviour {

	public int health = 100;

	public GameObject explosionPrefab;
	private float explosionLife = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Detect collision
	void OnCollisionEnter(Collision collision) {
		//Debug.Log("BOOOOOOM!");

		if(collision.gameObject.name == "Bullet(Clone)")
		{

			//RigidBody bulletRB = collision.gameObject.GetComponent<Rigidbody>;

			Destroy (collision.gameObject);

			this.health -= 10;

			if (this.health <= 0) {
				createExplosion();

				//destroy asteroid
				Destroy(this.gameObject);
			}
		}
	}

	void createExplosion(){
		Vector3 expPos = this.transform.position;
		Object exp = Instantiate(explosionPrefab, expPos, Quaternion.identity);
		Destroy(exp, explosionLife);
	}
}
