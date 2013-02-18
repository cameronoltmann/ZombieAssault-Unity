using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

	public float acceleration;
	public float direction;
	public Vector3 move;
	
	// Use this for initialization
	void Start () {
		direction = Random.value*2*Mathf.PI;
		SetMove (direction, acceleration);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void SetMove(float dir, float magnitude) {
		float x = Mathf.Cos(dir)*magnitude;
		float z = Mathf.Sin(dir)*magnitude;
		move = new Vector3(x, 0, z);
	}
		
	void FixedUpdate () {
		//if (Random.value>.99) {
		if (Random.value>.992){
			direction = Random.value*2*Mathf.PI;
			SetMove (direction, acceleration);
		}
		//rigidbody.AddForce (acceleration, 0f, 0f, ForceMode.Acceleration);
		rigidbody.AddForce(move, ForceMode.Acceleration);
	}
	


}
