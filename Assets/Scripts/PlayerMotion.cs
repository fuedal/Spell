using UnityEngine;
using System.Collections;

public class PlayerMotion : MonoBehaviour {

	Rigidbody rb;
	int speedMult = 15;
	bool canJump = true;


	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
	}
	

	void Update () 
	{
		NotDying ();
		rb.AddForce (transform.up * -9);
	}

	void OnCollisionEnter (Collision collision)
	{

		if (collision.collider.tag != "Walls") {
			canJump = true;
			Debug.Log ("Can Jump!");
		}
	}


	void NotDying()
	{
		float x = Input.GetAxis("left-X");
		float y = Input.GetAxis("left-Y");
		float rx = Input.GetAxis("right-X");
		if(Input.GetKey(KeyCode.Space) || Input.GetButton("A"))
		{
			Jump();
		}
		if(Input.GetKey(KeyCode.Q) || x < 0)
		  {
			MoveLeft();
		}
		if(Input.GetKey(KeyCode.W) || y < 0)
		{
			MoveForward();
		}
		if(Input.GetKey(KeyCode.S) || y > 0)
		{
			MoveBack();
		}
		if(Input.GetKey(KeyCode.E) || x > 0)
		{
			MoveRight();
		}
		if(Input.GetKey(KeyCode.A) || rx < 0)
		{
			TurnLeft();
		}
		if(Input.GetKey(KeyCode.D) || rx > 0)
		{
			TurnRight();
		}

	}

	void MoveForward()
	{
		transform.Translate(Vector3.forward * speedMult * Time.deltaTime);
	}
	void MoveBack()
	{
		transform.Translate(Vector3.back * speedMult * Time.deltaTime);
	}
	void MoveLeft()
	{
		transform.Translate(Vector3.left * speedMult * Time.deltaTime);
	}
	void MoveRight()
	{
		transform.Translate(Vector3.right * speedMult * Time.deltaTime);
	}
	void TurnLeft()
	{
		transform.Rotate (Vector3.down * speedMult * 5 * Time.deltaTime);
	}
	void TurnRight()
	{
		transform.Rotate (Vector3.up * speedMult * 5 * Time.deltaTime);
	}
	void Jump()
	{
		if (canJump == true) {
			rb.AddForce (transform.up * 750);
			canJump = false;
		}
	}


}
