using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public float attack = 5.0f;
	private EnemyHealth enemyHealth;

	public float attackTime = 1.0f;
	public float timer;

	void Start() {
		timer = attackTime;
		enemyHealth = GetComponent<EnemyHealth> ();
	}

	// 触发器被触发 会调用的方法
	void OnTriggerStay(Collider col) {
		if (col.tag == Tags.player && enemyHealth.hp > 0) {
			if (timer >= attackTime) {
				timer -= attackTime;

				// 触发攻击
				col.GetComponent<PlayerHealth>().TakeDamage(attack);
			}

			// 计时
			timer += Time.deltaTime;
		}
	}

}