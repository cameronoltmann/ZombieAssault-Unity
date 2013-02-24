using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	public LevelManager Level;
	public List<Strategy> Strategies;
	
	// Use this for initialization
	void Start () {
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		SetActorHierarchy();
		//ObjectParent = GameObject.Find (actorCategory);
		enabled = false;
		Time.timeScale = 0f;
		Level.Load();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			GameEventManager.TriggerGameOver ();
		}	
	}

	public void StartGame() {
		GameEventManager.TriggerGameStart();
	}
	
	private void GameStart() {
		enabled = true;
		Time.timeScale = 1f;
	}
	
	private void GameOver() {
		enabled = false;
		Time.timeScale = 0f;
	}
	
	private void SetActorHierarchy() {
		LevelManager.TerrainParent = GameObject.Find ("Terrain");
		Actor.ObjectParent = GameObject.Find ("Actors");
		Civilian.ObjectParent = GameObject.Find ("Neutrals");
	}
}
