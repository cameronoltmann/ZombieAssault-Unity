using UnityEngine;

public class GUIManager : MonoBehaviour {

	public Game TheGame;
	
	// Use this for initialization
	void Start () {
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown ("Jump")) {
			TheGame.StartGame();
			//GameEventManager.TriggerGameStart ();
		} else if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
	
	private void GameStart() {
		enabled = false;
	}
	
	private void GameOver() {
		enabled = true;
	}

}
