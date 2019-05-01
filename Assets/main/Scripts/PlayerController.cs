using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 0.1f;
    public float smoothRotation = 10f;
    public float animationSpeed = 1.5f;

    private CharacterController characterController;
    [SerializeField] private Animator animator;

    public bool isTalking = false;

    public virtual bool MainPlayer_IsTalking {
        set {
            isTalking = value;
        }
        get {
            return isTalking;
        }
    }

    public virtual string MainPlayer_Motion {
        set {
            animator.SetBool (value, true);
        }
    }

    private void Start () {
        characterController = GetComponent<CharacterController> ();
    }
    void FixedUpdate () {
        if (!isTalking) {
            var dh = Input.GetAxis ("Horizontal");
            var dv = Input.GetAxis ("Vertical");

            var targetVel = new Vector3 (dh, 0, dv);

            animator.SetFloat ("Speed", targetVel.magnitude);
            animator.speed = animationSpeed;

            if (targetVel.magnitude > 0.1f) {
                Quaternion rotation = Quaternion.LookRotation (targetVel);
                transform.rotation = Quaternion.Lerp (transform.rotation, rotation, Time.deltaTime * smoothRotation);

                animator.SetBool ("Dance", false);
            }

            characterController.Move (targetVel * speed);
        }
    }

}