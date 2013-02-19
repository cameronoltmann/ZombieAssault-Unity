using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

	public float acceleration;
	public float direction;
	public Vector3 move;
	public float maxSpeed;
	public Strategy strategy;
	public float consistency;
	public float thinkInterval;

	protected float nextThink;
	
	protected virtual void SetStrategy() {
		strategy = GameObject.Find ("/AI").GetComponent<Strategy>();
	}
	
	// Use this for initialization
	protected virtual void Start () {
		direction = Random.value*2*Mathf.PI;
		SetMove (direction, (float)(Random.value*.5+.25)*acceleration);
		SetStrategy();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= nextThink) {
			strategy.Think(this);
			nextThink += thinkInterval;
		}
	}
	
	public void SetMove(float dir, float magnitude) {
		float x = Mathf.Cos(dir)*magnitude;
		float z = Mathf.Sin(dir)*magnitude;
		move = new Vector3(x, 0, z);
	}
		
	void FixedUpdate () {
		if (rigidbody.velocity.magnitude < maxSpeed) {
			rigidbody.AddForce(move, ForceMode.Acceleration);
		}
	}
	


}
