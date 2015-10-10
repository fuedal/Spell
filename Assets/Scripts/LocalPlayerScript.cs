using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class LocalPlayerScript : NetworkBehaviour {
	[SerializeField] Camera localCamera;
	[SerializeField] AudioListener localSound;
	[SerializeField] private Transform whereToShootFireballs;
	public GameObject Fireballz;
	float timeLapse = 0;
	// Use this for initialization
	void Start () 
	{
		if (isLocalPlayer) 
		{
			GetComponent<PlayerMotion>().enabled = true;
			localCamera.enabled = true;
			localSound.enabled = true;
		}
	}
	void Update ()
	{
		if (isLocalPlayer) {
			timeLapse += Time.deltaTime;
			ShootingFireballz();
		}
	}
	void ShootingFireballz()
	{
		if (Input.GetKey (KeyCode.K) && timeLapse >= 1) 
		{
			Instantiate(Fireballz, whereToShootFireballs.TransformPoint(0,0,0.05f), whereToShootFireballs.rotation);
			timeLapse = 0;
		}

	}


}