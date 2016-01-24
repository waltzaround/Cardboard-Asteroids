using UnityEngine;
using System.Collections;

public class Thrust : MonoBehaviour {
    private bool thrustOn = false;
    public float speed = 0.25f;       // keep it from 0..1
    private Rigidbody rb;
    public GameObject playerHead; //assign the in-game instance of 'Head' from the Google Cardboard objects to allow movement along look direction
    private Transform trans;
    private Vector3 lookVector;
	private Vector3 forceVector;
	private static CardboardControl cardboard;
   

    // Use this for initialization
    void Start()
    {
		//cardboardControl trigger events are not currently working in Google Cardboard SDK 
		cardboard = GameObject.Find("CardboardControlManager").GetComponent<CardboardControl>();
		//cardboard.trigger.OnDown += CardboardDown;  // When the trigger goes down
		//cardboard.trigger.OnUp += CardboardUp;      // When the trigger comes back up
		// When the magnet or touch goes down and up within the "click threshold" time
		// That click speed threshold is configurable in the inspector
		//cardboard.trigger.OnClick += CardboardClick;

        rb = GetComponent<Rigidbody>();
    }

	/*
  	* In this demo, we randomize object colours for triggered events
  	*/
	/*private void CardboardDown(object sender) {
		Debug.Log("Trigger went down");
		//ChangeObjectColor("SphereDown");
		//thrustOn = true;
	}

	private void CardboardUp(object sender) {
		Debug.Log("Trigger came up");
		//ChangeObjectColor("SphereUp");
		//thrustOn = false;
	}

	private void CardboardClick(object sender) {
		Debug.Log("Trigger clicked");
		if (!thrustOn)
		{
			thrustOn = true;
		}
		else
		{
			thrustOn = false;
		}
	}*/


	
	// Update is called once per frame
	void Update () {

		trans = playerHead.GetComponent<Transform>();
        lookVector = trans.eulerAngles;

		if (Cardboard.SDK.Triggered)
        {
            if (!thrustOn)
            {
                thrustOn = true;

            }
            else {
                thrustOn = false;
            }
        }

        if (thrustOn)
        {
            forceVector = Vector3.Scale(trans.forward, lookVector);

			//add an instant velocity change along the current look direction
			//will be affected by drag of object this script is attached to
			rb.AddForce(trans.forward * speed, ForceMode.VelocityChange);
        }

    }

	void OnGUI() {
		//GUILayout.Box ("forceVector: " + forceVector.ToString() + ", thrustOn: "+thrustOn);
	}

}
