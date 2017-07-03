using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour {

	public float speed = 1;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		// 控制移动
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		// transform.Translate (new Vector3 (h, 0, v) * speed * Time.deltaTime);
		GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(h, 0, v) * speed * Time.deltaTime);

		// 控制动画
		if (h != 0 || v != 0) {
			anim.SetBool ("Move", true);
		} else {
			anim.SetBool ("Move", false);
		}

		// 控制转向
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;

		if (Physics.Raycast (ray, out hitInfo, 200)) {
			Vector3 target = hitInfo.point;
			target.y = transform.position.y;
			transform.LookAt (target);
		}

	}
}
