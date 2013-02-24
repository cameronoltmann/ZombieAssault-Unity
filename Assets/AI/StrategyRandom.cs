using UnityEngine;
using System.Collections;

public class StrategyRandom : Strategy {

	public override void Think(Actor actor) {
		if (Random.value>actor.consistency){
			actor.direction = actor.direction-Mathf.PI*.25f+Random.value*.5f*Mathf.PI;
			actor.SetMove (actor.direction, (float)(Random.value*.5+.25));
		}
	}
	
}
