using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NPCharacterContoller : MonoBehaviour {

	private Animator animator;
	[SerializeField]private Flowchart flowchart;

	void Start () {
		animator = GetComponent<Animator>();
		animator.speed = 1.5f;
		animator.SetBool("Dance",true);
	}
	
	void Update () {
		
	}

	public void TalkStart(){
		Debug.Log("TALK");
		flowchart.ExecuteBlock("New Block");
		DanceStop();
	}

	public void TalkEnd(){
		DanceStart();
	}

	public void DanceStop(){
		animator.SetBool("Dance",false);
	}
	public void DanceStart(){
		animator.SetBool("Dance",true);
	}
}
