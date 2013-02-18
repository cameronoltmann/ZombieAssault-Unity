using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public List<Transform> blocks;
	public Material[] actorPrefabs;
	public Transform[] blockPrefabs;
	public enum Blocks { Floor=0, Wall };
	public int Height;
	public int Width;

	protected Blocks[,] grid;
	
	// Use this for initialization
	void Start () {
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void AddBlock(Blocks b, Vector3 loc) {
		Transform prefab = blockPrefabs[(int)b];
		Vector3 prefabPos = prefab.localPosition;
		Vector3 prefabScale = prefab.localScale;
		Transform block = (Transform)Instantiate (prefab);
		block.parent = transform;
		block.localPosition = prefabPos + loc;
		block.localScale = prefabScale;
		blocks.Add (block);
	}
				
	private void GameStart() {
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
				AddBlock (Blocks.Floor, new Vector3(x, y, 0));
				// if grid cell isn't floor, add wall block
				if (grid[x,y] != Blocks.Floor) {
					AddBlock (grid[x,y], new Vector3(x, y, 1));
				}
			}
		}
		
	}
	
	private void GameOver() {
		Component[] allChildren = GetComponentsInChildren(typeof(Transform));
		foreach (Transform child in allChildren) {
			Console.WriteLine ("OMG");
			Console.WriteLine (child.ToString ());
		}
	}
}
