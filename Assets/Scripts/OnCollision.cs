using UnityEngine;

public class OnCollision : MonoBehaviour {

	// Detect collision
	void OnCollisionEnter(Collision collision) {
        Debug.Log("BOOOOOOM!");
	}
}
