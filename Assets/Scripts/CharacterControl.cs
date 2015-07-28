using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

	public float speed = 500f;
	public float turn = 90f;
	public float jump = 400f;
	public float maxSlope = 45f;
	public Rigidbody rbody;
	public PhysicMaterial material;
	public WheelCollider[] wheelColliders = new WheelCollider[4];

	private bool grounded = true;
	//private bool tooSteep = false;
	//private Vector3 prevPos;
	//private Vector3 movement;
	//private Vector3 cOM = transform.

	void Start()
	{
		//prevPos = transform.position;
		//Debug.Log(rbody.centerOfMass);
		rbody.centerOfMass = new Vector3(0,-1,0);
		//Debug.Log(rbody.centerOfMass);
	}

	// FixedUpdate is called once per physics frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && grounded) 
		{
			rbody.AddRelativeForce(0f, jump, 0f);
		}
	}
	void FixedUpdate () 
	{
		//movement = Vector3.zero;
		//Debug.Log(transform.rotation.z);
		if (transform.rotation.z > 0.5f || transform.rotation.z < -0.5f)
		{
			Debug.Log("fell!");
			GetComponent<AudioSource>().Play();
		}
		float x = Input.GetAxis ("Horizontal"); // imagine [A] = -1, [D] = +1
		float y = Input.GetAxis ("Vertical"); // imagine [W] = +1, [S] = -1
		
		// Trying to avoid sliding cuz we're skateboarding!!
		//if (!tooSteep)
		//{
			for (int i = 0; i < 4; i++)
			{
				wheelColliders[i].motorTorque = y * speed;
			}
		//}
		//rbody.AddRelativeForce(0f, 0f, y * speed * Time.deltaTime);
		//movement.z += y * 15;
		//transform.Translate(movement * Time.deltaTime);
		transform.Rotate ( 0f, x * turn * Time.deltaTime, 0f );
		//rbody.AddRelativeForce(-100f, 0f, 0f);
		//Vector3 direction = transform.position - prevPos;
		//rbody.AddRelativeForce(0f, -direction.y, 0f);
		//Debug.Log(direction);
		//prevPos = transform.position;
		//material.frictionDirection2 = transform.forward;
	}

	void OnCollisionStay(Collision collision)
	{
		for (int i = 0; i < collision.contacts.Length; i++)
		{
			ContactPoint contact = collision.contacts[i];
			//Debug.Log(Vector3.Angle(contact.normal, Vector3.up));
			if (Vector3.Angle(contact.normal, Vector3.up) < maxSlope)
			{
				grounded = true;
			}
			//else
			//{
			//	tooSteep = true;
			//}
		}
	}
	void OnCollisionExit()
	{
		grounded = false;
	}
}