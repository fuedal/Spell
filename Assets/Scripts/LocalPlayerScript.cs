using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class LocalPlayerScript : NetworkBehaviour {
	[SerializeField] Camera localCamera;
	[SerializeField] AudioListener localSound;
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

}