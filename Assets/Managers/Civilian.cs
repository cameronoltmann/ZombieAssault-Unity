using UnityEngine;
using System.Collections;

public class Civilian : Actor {

	protected override void SetStrategy() {
		strategy = GameObject.Find ("/AI").GetComponent<StrategyRandom>();
	}
	
}
