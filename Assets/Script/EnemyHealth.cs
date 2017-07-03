using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public AudioClip deathClip;
	public float hp = 100;


	private Animator anim;
	private UnityEngine.AI.NavMeshAgent agent;
	private EnemyMove move;
	private CapsuleCollider capsuleCollider;
	private ParticleSystem particleSystem;


	void Awake() {
		anim = GetComponent<Animator> ();
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		move = GetComponent<EnemyMove> ();
		capsuleCollider = GetComponent<CapsuleCollider> ();
		particleSystem = GetComponentInChildren<ParticleSystem> ();
	}

	public void TakeDamage(float damage, Vector3 hitPos) {
		if (hp <= 0) {
			return;
		}

		// 被射击效果
		particleSystem.transform.position = hitPos;
		particleSystem.Play ();

		GetComponent<AudioSource> ().Play ();

		hp -= damage;
		if (hp <= 0) {
			Dead ();
		}
	}

	// 处理敌人死亡之后的事情
	void Dead() {
		anim.SetBool ("Dead", true);
		agent.enabled = false;
		move.enabled = false;

		capsuleCollider.enabled = false;

		// 播放死亡音效
		AudioSource.PlayClipAtPoint(deathClip, transform.position, 1.0f);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.hp <= 0) {
			transform.Translate (Vector3.down * Time.deltaTime * 0.5f);
			if (transform.position.y <= -3) {
				Destroy (this.gameObject);
			}
		}
	}
}
