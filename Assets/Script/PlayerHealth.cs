using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public float hp = 100;
	public float smoothing = 5;

	private Animator anim;
	private PlayerMove playerMove;
	private SkinnedMeshRenderer bodyRenderer;

	void Awake() {
		anim = this.GetComponent<Animator> ();
		this.playerMove = GetComponent<PlayerMove> ();
		this.bodyRenderer = transform.Find ("Player").GetComponent<Renderer>() as SkinnedMeshRenderer;

	}

	void Update() {
		// 回复身体颜色
		bodyRenderer.material.color = Color.Lerp(bodyRenderer.material.color, Color.white, smoothing * Time.deltaTime);
	}

	public void TakeDamage(float damage) {
		if (hp <= 0) {
			return;
		}
		this.hp -= damage;

		// 出血
		bodyRenderer.material.color = Color.red;

		if (this.hp <= 0) {
			anim.SetBool ("Dead", true);
			Dead ();
		}
	}


	void Dead() {
		this.playerMove.enabled = false;
	}
}