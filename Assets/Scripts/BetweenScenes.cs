using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BetweenScenes : MonoBehaviour {

	public Text resultsText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float likes = CatController.score;
		float dislikes = CatController.antiScore;
		resultsText.text = "You have " + likes.ToString() + " likes and " + dislikes.ToString() + " dislikes.";

		
	}
}
