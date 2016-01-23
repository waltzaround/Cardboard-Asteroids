using UnityEngine;
using System.Collections;

public class Thrust : MonoBehaviour {
    private bool thrustOn = false;
    public float speed = 0.25f;       // keep it from 0..1
    private Rigidbody rb;
    public GameObject playerHead;
    private Transform trans;
    private Vector3 lookVector;
	private Vector3 forceVector;
   

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
	
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
		GUILayout.Box ("forceVector: " + forceVector.ToString() + ", thrustOn: "+thrustOn);
	}
}
