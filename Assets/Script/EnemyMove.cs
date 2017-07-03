using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {

	private NavMeshAgent agent;
	private Transform player;
	private Animator anim;

	void Awake() {
		agent = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();
	}

	void Start () {
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
	}
	
	void Update () {
		// 判断停止
		if (Vector3.Distance (transform.position, player.position) < 1.2f) {
			agent.isStopped = true;
			anim.SetBool ("Move", false);
		} else {
			agent.isStopped = false;
			agent.SetDestination (player.position);
			anim.SetBool ("Move", true);
		}
	}
}
