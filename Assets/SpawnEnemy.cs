using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	// 字段
	public GameObject enemyProfab;
	private float spawnTime = 3.0f;
	private float timer = 0;

	void Start() {
		InvokeRepeating ("ACC", 0, 0.05F);
	}

	void ACC () {
		spawnTime += 0.001f;
	}

	// 每一帧都会被调用
	void Update () {
		timer += Time.deltaTime;
		if (timer >= spawnTime) {
			timer -= spawnTime;

			Spwan ();
		}
	}

	void Spwan() {
		GameObject.Instantiate (enemyProfab, transform);
	}
}
