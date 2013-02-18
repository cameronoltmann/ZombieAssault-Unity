using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			GameEventManager.TriggerGameOver ();
		}	
	}
	
	private void GameStart() {
		enabled = true;
	}
	
	private void GameOver() {
		enabled = false;
	}
}
