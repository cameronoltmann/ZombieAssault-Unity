using UnityEngine;

public class GUIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameEventManager.GameStart += GameStart;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown ("Jump")) {
			GameEventManager.TriggerGameStart ();
		} else if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
	
	private void GameStart() {
		enabled = false;
	}

}
