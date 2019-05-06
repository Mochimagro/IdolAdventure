using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SubCharacterController : MonoBehaviour {

	public string characterName;
	[SerializeField] private GameObject characterFBX;

	public Transform target;

	private NavMeshAgent agent;
	private Animator animator;

	void Start () {
		animator = characterFBX.GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();

		animator.speed = 1.5f;
	}

	void Update () {
		animator.SetFloat ("Speed", Mathf.Clamp01 (agent.velocity.magnitude));

		agent.destination = target.position;

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			animator.SetBool ("Dance", !animator.GetBool ("Dance"));
			//animator.SetTrigger("Dance");
		}

		if (agent.velocity.magnitude > 0.1f) {
			animator.SetBool ("Dance", false);
		}
	}

}