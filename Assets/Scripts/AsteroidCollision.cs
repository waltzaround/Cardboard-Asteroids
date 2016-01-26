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
				createExplosionAtPos(collision.transform.position,this.gameObject.transform.localScale.magnitude);

				//destroy asteroid
				Destroy(this.gameObject);
			}
		}
	}

	void createExplosionAtPos(Vector3 pos,float maxScale){
		Vector3 expPos = this.transform.position;
		GameObject exp = Instantiate(explosionPrefab, pos, Quaternion.identity) as GameObject;

		ExplosionDamage explosionDamage = exp.GetComponent<ExplosionDamage>();

		explosionDamage.transform.localScale = new Vector3 (500, 500, 500);
		explosionDamage.maxScale = maxScale;

		Destroy(exp, explosionLife);
	}
}
