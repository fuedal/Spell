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
		if(Input.GetKey(KeyCode.Space))
		{
			Jump();
		}
		if(Input.GetKey(KeyCode.Q))
		  {
			MoveLeft();
		}
		if(Input.GetKey(KeyCode.W))
		{
			MoveForward();
		}
		if(Input.GetKey(KeyCode.S))
		{
			MoveBack();
		}
		if(Input.GetKey(KeyCode.E))
		{
			MoveRight();
		}
		if(Input.GetKey(KeyCode.A))
		{
			TurnLeft();
		}
		if(Input.GetKey(KeyCode.D))
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
