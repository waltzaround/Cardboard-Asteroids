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
   

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        playerhead = GameObject.Find("Head");

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





        if (Cardboard.SDK.CardboardTriggered)
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
            Vector3 charlie = Vector3.Scale(trans.forward, lookVector);
            rb.AddForce(charlie * 0.00005f);
            //Debug.Log(rb.ToString("F4"));
        }

    }
}
