using UnityEngine;
using System.Collections;

public class PlayerMotion : MonoBehaviour {
	public GameObject fireball;
	Rigidbody rb;
	int speedMult = 10;
	bool canJump = false;
	double timeLapse = 0;

	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
	}
	

	void Update () 
	{
		timeLapse += Time.deltaTime;
		NotDying ();


	}

	void OnCollisionEnter ()
	{

			canJump = true;
			Debug.Log("Can Jump!");

	}


	void NotDying()
	{
		if(Input.GetKey(KeyCode.Space))
		{
			Jump ();
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
		if (Input.GetKey (KeyCode.K)) 
		{
			ShootingFireballs();
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
			rb.AddForce (transform.up * 500);
			canJump = false;
		}
	}
	void ShootingFireballs()
	{	if (timeLapse >= 1.0) {
			Instantiate (fireball, this.transform.position, this.transform.rotation);
			timeLapse -= 1.0;
		}
	}

}
