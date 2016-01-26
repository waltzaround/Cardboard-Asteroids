using UnityEngine;
using System.Collections;

public class BulletTargeting : MonoBehaviour
{
    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject Bullet_Emitter;

    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;

    //Enter the Speed of the Bullet from the Component Inspector.
    public float Bullet_Forward_Force;
	public float bulletForceMin;

    private Rigidbody rb;
    public GameObject playerHead; //assign the in-game instance of 'Head' from the Google Cardboard objects to allow movement along look direction
    //private Transform trans;
    //private Vector3 lookVector;
    //private Vector3 forceVector;
	private static CardboardControl cardboard;
    private Rigidbody Temporary_RigidBody;
	private bool autoFireOn = false;
	private bool autoFireKeyOn = false;
	public float rateOfFire = 0.2F;

    // Use this for initialization
    void Start()
    {
		cardboard = GameObject.Find("CardboardControlManager").GetComponent<CardboardControl>();
        rb = GetComponent<Rigidbody>();
		//Physics.IgnoreLayerCollision (9, this.gameObject.layer);
		//Physics.IgnoreLayerCollision (9, 9);

		// When the thing we're looking at changes, determined by a gaze
		// The gaze distance and layer mask are public as configurable in the inspector
		cardboard.gaze.OnChange += CardboardGazeChange;

		// When we've been staring at an object
		cardboard.gaze.OnStare += CardboardStare;

		// When we rotate the device into portrait mode
		cardboard.box.OnTilt += CardboardMagnetReset;

		//cardboard.pointer.Show();

		InvokeRepeating("FireCheck", 2, rateOfFire);
    }

	private void CardboardMagnetReset(object sender) {
		// Resetting the magnet will reset the polarity if up and down are confused
		// This occasionally happens when the device is inserted into the enclosure
		// or if the magnetometer readings are weak enough to cut in and out
		Debug.Log("Device tilted");
		cardboard.trigger.ResetMagnetState();
	}

	// Be sure to set the Reticle Layer Mask on the CardboardControlManager
	// to grow the reticle on the objects you want. The default is everything.

	//TODO: detect if object is destroyed. Check if current gaze object still exists?


	private void CardboardGazeChange(object sender) {
		// You can grab the data from the sender instead of the CardboardControl object
		CardboardControlGaze gaze = sender as CardboardControlGaze;
		// We can access to the object we're looking at
		// gaze.IsHeld will make sure the gaze.Object isn't null
		if (gaze.IsHeld() && gaze.Object().name.Contains("Asteroid")) {
			//ChangeObjectColor(gaze.Object().name);
			// Highlighting can help identify which objects can be interacted with
			// The pointer is hidden by default but we already toggled that in the inspector
			//cardboard.reticle.Hide();
			cardboard.reticle.Highlight(Color.red);
			autoFireOn = true;
		}
		// We also can access to the last object we looked at
		// gaze.WasHeld will make sure the gaze.PreviousObject isn't null
		if (gaze.WasHeld() && gaze.PreviousObject().name.Contains("Asteroid")) {
			//ResetObjectColor(gaze.PreviousObject().name);
			// Use these to undo pointer hiding and highlighting
			//cardboard.reticle.Show();
			autoFireOn = false;
			cardboard.reticle.ClearHighlight();
		}
	}

	private void Fire(){
		//Debug.Log("Firing...");

		//trans = playerHead.GetComponent<Transform>();
		//lookVector = trans.eulerAngles;
		//forceVector = Vector3.Scale(trans.forward, lookVector);
		//rb.AddForce(trans.forward * speed, ForceMode.VelocityChange);

		//The Bullet instantiation happens here.
		GameObject BulletObject;
		BulletObject = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
		//BulletObject.layer = 9;
		//bullet inaccuracy


		//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
		//This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
		BulletObject.transform.Rotate(Vector3.left * 90);

		//Retrieve the Rigidbody component from the instantiated Bullet and control it.

		Temporary_RigidBody = BulletObject.GetComponent<Rigidbody>();

		//Physics.IgnoreCollision(Temporary_Bullet_Handler.GetComponent<Collider>(), GetComponent<Collider>());

		//Thrust thrust = this.gameObject.GetComponent<Thrust>();



		//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force. 
		Temporary_RigidBody.AddForce(Bullet_Emitter.transform.forward * Bullet_Forward_Force * (bulletForceMin + rb.velocity.magnitude),ForceMode.Impulse);

		// Temporary_RigidBody.velocity = transform.TransformDirection(Vector3.forward * 100);

		//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
		Destroy(BulletObject, 10.0f);
	}

	private void FireCheck(){

		if (autoFireOn)
		{
			Bullet_Emitter.GetComponent<CardboardAudioSource>().Play();
            Fire ();
		}
	}

	private void CardboardStare(object sender) {
		CardboardControlGaze gaze = sender as CardboardControlGaze;
		if (gaze.IsHeld() && gaze.Object().name.Contains("Asteroid")) {
			// Be sure to hide the cursor when it's not needed
			//cardboard.reticle.Hide();

			autoFireOn = true;

		}
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown ("z")) {
			Debug.Log ("Auto fire key on");
			//Fire ();

			if (!autoFireKeyOn) {
				autoFireKeyOn = true;
			} else {
				autoFireKeyOn = false;
			}
		}
        
    }
    void OnGUI()
    {
		GUILayout.Box("currentSpeed: " + rb.velocity.magnitude.ToString());
    }

}