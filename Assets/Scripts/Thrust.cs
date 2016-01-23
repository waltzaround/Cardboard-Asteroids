using UnityEngine;
using System.Collections;

public class Thrust : MonoBehaviour {
    private bool thrustOn = false;
    public float sensitivity = 0.25f;       // keep it from 0..1
    private Rigidbody rb;
   // public GameObject[] playerheads;
    public GameObject playerhead;
    private Transform trans;
    private Vector3 lookVector;
	private Vector3 forceVector;
   

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //playerhead = GameObject.Find("Head");

   //     if (playerhead == null)
     //       playerheads = GameObject.FindGameObjectsWithTag("PlayerHead");
    }
	
	// Update is called once per frame
	void Update () {


        //        trans = playerheads[0].GetComponent("Transform");

        //      Vector3 lookVector = trans.eulerAngles;

        trans = playerhead.GetComponent<Transform>();
        lookVector = trans.eulerAngles;
        

        //Vector3 dir = new Vector3();			// create (0,0,0)





		if (Cardboard.SDK.Triggered)
        {
            if (!thrustOn)
            {
                thrustOn = true;

            }
            else {
                thrustOn = false;
            }

            //something here;   
        }

        if (thrustOn)
        {
            //     dir.z += 0.05f;
            //  rb.AddForce
            forceVector = Vector3.Scale(trans.forward, lookVector);
			//relative force adds force to the object in local space without taking into consideration the world around it
			//rb.AddRelativeForce(forceVector * 0.005f);


			//add an instant velocity change along the current look direction
			//rb.AddForce(trans.forward * 0.05f, ForceMode.VelocityChange);

			rb.AddForce(trans.forward * 0.1f, ForceMode.VelocityChange);
        }

    }

	void OnGUI() {
		GUILayout.Box ("forceVector: " + forceVector.ToString() + ", thrustOn: "+thrustOn);
	}
}
