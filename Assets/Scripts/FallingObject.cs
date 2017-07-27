using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour {

	public int speed;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		//vertical movement of falling objects
		transform.Translate (Vector3.down * Time.deltaTime * UnityEngine.Random.Range(4.0f,12.0f));

		if (transform.position.y < -17) {
			Destroy(gameObject);
		}
		
	}
}
