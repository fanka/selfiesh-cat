using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Reload(){
		SceneManager.GetActiveScene();
	}

	public void LoadGame(string level){
		SceneManager.LoadScene("scene1");
	}

	public void LoadMenu(string level){
		SceneManager.LoadScene("MainMenu");
			}

	public void LoadHowToPlay(string level){
		SceneManager.LoadScene("HowToPlay");
	}
}
