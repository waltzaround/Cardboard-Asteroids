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

    private Rigidbody rb;
    public GameObject playerHead; //assign the in-game instance of 'Head' from the Google Cardboard objects to allow movement along look direction
    private Transform trans;
    private Vector3 lookVector;
    private Vector3 forceVector;

    private Rigidbody Temporary_RigidBody;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		Physics.IgnoreLayerCollision (9, this.gameObject.layer);
		Physics.IgnoreLayerCollision (9, 9);
    }

    // Update is called once per frame
    void Update()
    {

        trans = playerHead.GetComponent<Transform>();
        lookVector = trans.eulerAngles;
        forceVector = Vector3.Scale(trans.forward, lookVector);
        //rb.AddForce(trans.forward * speed, ForceMode.VelocityChange);





        if (Input.GetKeyDown("z"))
        {
            //The Bullet instantiation happens here.
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
			Temporary_Bullet_Handler.layer = 9;
			//bullet inaccuracy


            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

            //Retrieve the Rigidbody component from the instantiated Bullet and control it.

            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

			//Physics.IgnoreCollision(Temporary_Bullet_Handler.GetComponent<Collider>(), GetComponent<Collider>());

			//Thrust thrust = this.gameObject.GetComponent<Thrust>();



            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force. 
			Temporary_RigidBody.AddForce(Bullet_Emitter.transform.forward * Bullet_Forward_Force, ForceMode.Impulse);

           // Temporary_RigidBody.velocity = transform.TransformDirection(Vector3.forward * 100);

            //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
            Destroy(Temporary_Bullet_Handler, 10.0f);
        }
    }
    void OnGUI()
    {
        //GUILayout.Box("forceVector: " + Temporary_RigidBody.ToString());
    }

}