using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChaser : MonoBehaviour {

	
	public Transform target;
	private Vector3 offset;
	void Start () {
		offset = GetComponent<Transform>().position - target.position;
	}
	
	void Update () {
		transform.position = target.position + offset;
	}
}
