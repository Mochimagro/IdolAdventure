using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerTalkManager))]
public class PlayerController : MonoBehaviour {

	public float speed = 0.1f;
	public float smoothRotation = 10f;
	public float animationSpeed = 1.5f;

	private CharacterController characterController;
	private Animator animator;
	[SerializeField]private bool isTalk;

	private void Start() {
		characterController = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		isTalk = false;
	}

	private void Update() {
		/*
		if(Input.GetKeyDown(KeyCode.Space)){
			animator.SetBool("Dance",!animator.GetBool("Dance"));
			//animator.SetTrigger("Dance");
		}
		*/
	}

	void FixedUpdate(){
		var dh = Input.GetAxis("Horizontal");
		var dv = Input.GetAxis("Vertical");

		var targetVel = new Vector3(dh,0,dv);

		animator.SetFloat("Speed",targetVel.magnitude);
		animator.speed = animationSpeed;

		if(targetVel.magnitude > 0.1f){
			Quaternion rotation = Quaternion.LookRotation(targetVel);
			transform.rotation = Quaternion.Lerp(transform.rotation,rotation,Time.deltaTime * smoothRotation);
		
			animator.SetBool("Dance",false);
		}

		characterController.Move(targetVel * speed);
	}

	private void OnTriggerStay(Collider other) {
		if(Input.GetKeyDown(KeyCode.Space) && other.gameObject.CompareTag("NPC")){
			if(!isTalk){
				other.GetComponent<NPCharacterContoller>().TalkStart();
				isTalk = true;
			}else{
				other.GetComponent<NPCharacterContoller>().TalkEnd();
				isTalk = false;
			}
			
		}
	}

}
