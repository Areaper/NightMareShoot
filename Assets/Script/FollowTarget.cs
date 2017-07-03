using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

	private Transform player;
	public float smoothing = 3;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetPos = player.position + new Vector3 (0, 6, -6);

		Transform trans = GetComponent<Transform> ();
		trans.position = Vector3.Lerp (trans.position, targetPos, smoothing * Time.deltaTime);
	}
}
