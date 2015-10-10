using UnityEngine;
using System.Collections;

public class FireballSelfDestruct : MonoBehaviour {
	double lifeSpan = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lifeSpan += Time.deltaTime;
		if (lifeSpan >= 2) {
			Destroy(this.gameObject);
		}
	}
}
