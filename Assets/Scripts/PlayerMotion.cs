using UnityEngine;
using System.Collections;

public class PlayerMotion : MonoBehaviour {

	Rigidbody rb;
	int speedMult = 15;
	float extraSpeedMult = 1.0f;
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
		extraSpeedMult = 1.0f;
		speedMult = 15;
		float x = Input.GetAxis("left-X");
		float y = Input.GetAxis("left-Y");
		float rx = Input.GetAxis("right-X");
		float lt = Input.GetAxis("left trigger");
		if(Input.GetKey(KeyCode.Space) || Input.GetButton("A") || (lt > 0))
		{
			Jump();
		}
		if(Input.GetKey(KeyCode.Q) || x < 0)
		{
			extraSpeedMult = x*x;
			MoveLeft();
		}
		if(Input.GetKey(KeyCode.W) || y < 0)
		{
			extraSpeedMult = y*y;
			MoveForward();
		}
		if(Input.GetKey(KeyCode.S) || y > 0)
		{
			extraSpeedMult = y*y;
			MoveBack();
		}
		if(Input.GetKey(KeyCode.E) || x > 0)
		{
			extraSpeedMult = x*x;
			MoveRight();
		}
		if(Input.GetKey(KeyCode.A) || rx < 0)
		{
			extraSpeedMult =Mathf.Abs (rx);
			TurnLeft();
		}
		if(Input.GetKey(KeyCode.D) || rx > 0)
		{
			extraSpeedMult = rx;
			TurnRight();
		}
	}

	void MoveForward()
	{
		Vector3 t = Vector3.forward * Mathf.FloorToInt(speedMult * Time.deltaTime * Mathf.Sqrt (extraSpeedMult) * 1000)/1000;
		transform.Translate(t);
	}
	void MoveBack()
	{
		Vector3 t = Vector3.back * Mathf.FloorToInt(speedMult * Time.deltaTime * Mathf.Sqrt (extraSpeedMult) * 1000)/1000;
		transform.Translate(t);
	}
	void MoveLeft()
	{
		Vector3 t = Vector3.left * Mathf.FloorToInt(speedMult * Time.deltaTime * Mathf.Sqrt (extraSpeedMult) * 1000)/1000;
		transform.Translate(t);
	}
	void MoveRight()
	{
		Vector3 t = Vector3.right * Mathf.FloorToInt(speedMult * Time.deltaTime * Mathf.Sqrt (extraSpeedMult) * 1000)/1000;
		transform.Translate(t);
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
