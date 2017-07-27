using System.Collections;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof (AudioSource))]

public class CatController : MonoBehaviour {

	public Camera cam;
	private float maxWidth;

	public Text ScoreText;
	public Text AntiScoreText;
	public static int score;
	public static int antiScore;
	public Text winText;
	public AudioClip[] sound;
	AudioSource camSound;
	//AudioSource bgSound;



	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		// Setting camera and size
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		maxWidth = targetWidth.x;
		score = 0;
		antiScore = 0;

		//setting ScoreCounter
		SetScoreText ();
		SetAntiScoreText ();

		//setting music and backgroud music
		camSound = GetComponent<AudioSource>();
		camSound.PlayOneShot (sound [1], 0.5f);
		//bgSound = GetComponent<AudioSource>();
		//bgSound.Play();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//moving camera horizontally
		Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
		Vector3 targetPosition = new Vector3 (rawPosition.x, 0.0f, 0.0f);
		float targetWidth = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);
		targetPosition = new Vector3 (targetWidth, targetPosition.y, targetPosition.z);
		GetComponent<Rigidbody2D>().MovePosition(targetPosition);
		
	}

	// taking photos (in correct place and with click)
	void OnTriggerStay2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Point") {

			if (Input.GetMouseButtonDown (0)) {
				
				camSound.PlayOneShot(sound[0], 0.7F);
				score = score + 1;
				print ("Selfie done" + score);

				SetScoreText ();
			}

		} 

		else if (other.gameObject.tag == "Danger") {

			if (Input.GetMouseButtonDown (0)) {
				camSound.PlayOneShot(sound[0], 0.7F);
				antiScore = antiScore +1;
				print ("Oups!" + antiScore);

				SetAntiScoreText ();
			}
		} 

		else if (other.gameObject.tag == "Fortune") {
			if (Input.GetMouseButtonDown (0)) {
				camSound.PlayOneShot(sound[0], 0.7F);
				score = score + 3;
				print ("Great!" + score);

				SetScoreText ();
			}
		}


	}
	// function for updating score
	void SetScoreText()
	{
		
		ScoreText.text = "Likes: " + score.ToString ();


		//if (score >= 20)
			//winText.text = "You win!";

	}


	void SetAntiScoreText()
	{

		AntiScoreText.text = "Dislikes: " + antiScore.ToString ();


		//if (score >= 20)
		//winText.text = "You win!";

	}


}
