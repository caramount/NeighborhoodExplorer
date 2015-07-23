using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

	public float speed = 500f;
	public float turn = 90f;
	public float jump = 1000f;
	public float maxSlope = 60f;
	public Rigidbody rbody;

	private bool grounded = true;

	// FixedUpdate is called once per physics frame
	void FixedUpdate () {
		if (Input.GetKeyDown(KeyCode.Space) && grounded) 
		{
			rbody.AddRelativeForce(0f, jump, 0f);
		}

		float x = Input.GetAxis ("Horizontal"); // imagine [A] = -1, [D] = +1
		float y = Input.GetAxis ("Vertical"); // imagine [W] = +1, [S] = -1
		
		rbody.AddRelativeForce (0f, 0f, y * speed * Time.deltaTime );
		transform.Rotate ( 0f, x * turn * Time.deltaTime, 0f );
	}

	void OnCollisionStay(Collision collision)
	{
		for (int i = 0; i < collision.contacts.Length; i++)
		{
			ContactPoint contact = collision.contacts[i];
			if (Vector3.Angle(contact.normal, Vector3.up) < maxSlope)
			{
				grounded = true;
			}
		}
	}
	void OnCollisionExit()
	{
		grounded = false;
	}
}