using UnityEngine;
//using System;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public List<Transform> blocks;
	public List<Transform> actors;
	public Transform[] actorPrefabs;
	public Transform[] blockPrefabs;
	public enum Blocks { Floor=0, Wall };
	public enum Actors { Actor=0, Soldier, Civilian, Zombie, Corpse };
	public int Height;
	public int Width;
	public int NumActors;
	public static GameObject TerrainParent;
	
	protected Blocks[,] grid;
	
	// Use this for initialization
	void Start () {
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void AddToLevel(Transform prefab, Vector3 loc, List<Transform> objects, GameObject parent) {
		Vector3 prefabPos = prefab.localPosition;
		Vector3 prefabScale = prefab.localScale;
		Transform obj = (Transform)Instantiate (prefab);
		obj.parent = parent.transform;
		obj.localPosition = prefabPos + loc;
		obj.localScale = prefabScale;
		obj.gameObject.layer = parent.layer;
		objects.Add (obj);
	}
	
	private void AddBlock(Blocks b, Vector3 loc) {
		Transform prefab = blockPrefabs[(int)b];
		AddToLevel (prefab, loc, blocks, TerrainParent);
		/*
		Vector3 prefabPos = prefab.localPosition;
		Vector3 prefabScale = prefab.localScale;
		Transform block = (Transform)Instantiate (prefab);
		block.parent = transform;
		block.localPosition = prefabPos + loc;
		block.localScale = prefabScale;
		blocks.Add (block);
		*/
	}
	
	private void AddActor(Actors a, Vector3 loc) {
		Transform prefab = actorPrefabs[(int)a];
		GameObject parent = null;
		switch (a) {
		case Actors.Actor:
			parent = Actor.ObjectParent;
			break;
		case Actors.Civilian:
			parent = Civilian.ObjectParent;
			break;
		case Actors.Soldier:
			parent = Civilian.ObjectParent;
			break;
		case Actors.Zombie:
			parent = Civilian.ObjectParent;
			break;
		case Actors.Corpse:
			parent = Civilian.ObjectParent;
			break;
		}
		AddToLevel (prefab, loc, actors, parent);
	}
		
	public void Load() {
		// load level data
		grid = new Blocks[Width, Height];
		for (int y=0; y<Height; y++) {
			for (int x=0; x<Width; x++) {
				if (x==0 || y==0 || x==Width-1 || y==Height-1) {
					grid[x,y] = Blocks.Wall;
				} else {
					grid[x,y] = Blocks.Floor;
				}
			}
		}
		// generate blocks
		for (int y=0; y<Height; y++) {
			for (int x=0; x<Width; x++) {
				AddBlock (Blocks.Floor, new Vector3(x, 0, y));
				// if grid cell isn't floor, add wall block
				if (grid[x,y] != Blocks.Floor) {
					AddBlock (grid[x,y], new Vector3(x, 1, y));
				}
			}
		}
		// add actors
		for (int i=0; i<NumActors; i++) {
			bool bad = true;
			float x=0, y=0;
			while (bad) {
				x = Random.value*(Width-3)+1.5f;
				y = Random.value*(Width-3)+1.5f;
				bad = Physics.CheckSphere (new Vector3(x, 1.5f, y), .2f);
			}
			AddActor(Actors.Civilian, new Vector3(x, 1.5f, y));
		}
	}
	
	private void GameStart() {
		
	}
	
	private void GameOver() {
		//Component[] allChildren = GetComponentsInChildren(typeof(Transform));
	}
}
