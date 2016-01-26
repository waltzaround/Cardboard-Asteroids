using UnityEngine;
using System.Collections;

public class ExplosionDamage : MonoBehaviour {

	public float maxScale = 8f; //Maximum explosion range
	public float velocity = 2f; //Explosion velocity

	float scale = 1f;

	void Start(){

		//Collider as trigger
		this.GetComponent<Collider>().isTrigger = true;

	}

	void Update () {

		//Modify Transform Scale, to change explosion range.
		scale += velocity*Time.deltaTime;

		if(this.scale>this.maxScale) Destroy(this.gameObject);
		else this.transform.localScale = Vector3.one * this.scale;

	}
}
