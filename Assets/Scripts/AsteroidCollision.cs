using UnityEngine;
using System.Collections;

public class AsteroidCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Detect collision
	void OnCollisionEnter(Collision collision) {
		Debug.Log("BOOOOOOM!");
	}
}
