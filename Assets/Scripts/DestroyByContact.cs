using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion; 
	public GameObject playerExplosion; 
	public int scoreValue; 
	private GameController gameController; 

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController"); 
		if(gameControllerObject!=null)
			gameController = gameControllerObject.GetComponent <GameController>(); 
		if(gameController==null)
			Debug.Log ("Cannot find a game controller object script"); 
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag=="Boundary") return; 

		// explode 
		Instantiate(explosion, transform.position, transform.rotation); 
		if(other.tag=="Player") {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation); 
			gameController.GameOver(); 
		}

		gameController.addScore(scoreValue); 

		// mark objects for deletion 
		Destroy(other.gameObject); 
		Destroy(gameObject); 
	} 
}
