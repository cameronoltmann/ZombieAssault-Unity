using UnityEngine;
using System.Collections;

public class StrategyRandom : Strategy {

	public override void Think(Actor actor) {
		if (Random.value>actor.consistency){
			actor.direction = Random.value*2*Mathf.PI;
			actor.SetMove (actor.direction, (float)(Random.value*.5+.25)*actor.acceleration);
		}
	}
	
}
