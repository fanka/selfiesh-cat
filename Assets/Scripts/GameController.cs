using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Camera cam;
	//public GameObject aim;

	public GameObject[] aims;

	public int aimSpawn;

	private float maxWidth;

	public float timeLeft = 20.0f;



	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		//aims = new GameObject[6];
		//aimSpawn = UnityEngine.Random.Range (0, 6);

		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		maxWidth = targetWidth.x;
		StartCoroutine (Spawn ());
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (timeLeft <= 0.0f)
			SceneManager.LoadScene ("RoundResults");
		
		timeLeft -= Time.deltaTime;


	}

	IEnumerator Spawn () {
		

		// aims [0] = GameObject.Find ("sandwich");
		// aims [1] = GameObject.Find ("quokka");
		//aims [2] = GameObject.Find ("cake");
		//aims [3] = GameObject.Find ("cheese");
		//aims [4] = GameObject.Find ("plant");
		//aims [5] = GameObject.Find ("New Prefab");


		// yield return new WaitForSeconds (1.0f);
		yield return new WaitForSeconds (1.0f);
		while (timeLeft>0) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-maxWidth, maxWidth), transform.position.y, 0.0f);
			Instantiate (aims[UnityEngine.Random.Range(0,5)], spawnPosition, Quaternion.identity);
			yield return new WaitForSeconds (Random.Range(1.0f, 2.0f));
		}
	
	}
}
