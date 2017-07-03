using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public float attack = 30;


	// 默认每秒射击次数
	public float shootRate = 2;
	private float timer = 0;
	private ParticleSystem particleSystem;
	private LineRenderer lineRenderer;


	// Use this for initialization
	void Start () {
		particleSystem = GetComponentInChildren<ParticleSystem> ();
		lineRenderer = GetComponent<LineRenderer> () as LineRenderer;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 1 / shootRate) {
			timer -= 1 / shootRate;
			Shoot ();
		}
	}

	// 射击方法
	void Shoot() {
		GetComponent<Light> ().enabled = true;
		particleSystem.Play ();

		this.lineRenderer.enabled = true;
		lineRenderer.SetPosition (0, transform.position);
		Ray ray = new Ray (transform.position, transform.forward);

		RaycastHit hitInfo;
		if (Physics.Raycast (ray, out hitInfo)) {
			lineRenderer.SetPosition (1, hitInfo.point);

			// 判断当前的射击有没有碰撞到敌人
			if (hitInfo.collider.tag == Tags.enemy) {
				hitInfo.collider.GetComponent<EnemyHealth> ().TakeDamage (attack, hitInfo.point);
			}

		} else {
			lineRenderer.SetPosition (1, transform.position + transform.forward * 100);
		}

		GetComponent<AudioSource> ().Play ();

		Invoke ("ClearEffect", 0.05f);
	}

	void ClearEffect() {
		GetComponent<Light> ().enabled = false;
		lineRenderer.enabled = false;
	}
}
