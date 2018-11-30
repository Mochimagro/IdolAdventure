using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sampleController : MonoBehaviour {

	public float speed;
	public float smoothRot;

	private CharacterController characterController;
	private Animator animator;

	void Start () {
		characterController = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
	}
	

	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Vector3 direction = new Vector3(h,0,v);

		animator.SetFloat("Speed",direction.magnitude);

		if(direction.magnitude >= 0.1f){
			Quaternion rotation = Quaternion.LookRotation(direction);
			transform.rotation = Quaternion.Lerp(transform.rotation,rotation,Time.deltaTime * smoothRot);
		}

		characterController.Move(direction * speed);
	}
}
