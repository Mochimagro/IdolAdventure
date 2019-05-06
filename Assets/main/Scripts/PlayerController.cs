using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public string characterName;
    [SerializeField] private GameObject characterFBX;

    public float moveSpeed = 0.1f;
    private float dashSpeed = 1.0f;
    private bool dash = false;
    public float smoothRotation = 10f;
    public float animationSpeed = 1.5f;

    private CharacterController characterController;
    private Animator animator;

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
        animator = characterFBX.GetComponent<Animator> ();
        characterController = GetComponent<CharacterController> ();
        animator.speed = animationSpeed;

    }
    void FixedUpdate () {
        if (!isTalking) {
            var dh = Input.GetAxis ("Horizontal");
            var dv = Input.GetAxis ("Vertical");

            var targetVel = new Vector3 (dh, 0, dv);

            if (Input.GetButtonDown ("Fire2")) {
                dash = true;
                DOTween.To (
                    () => dashSpeed,
                    value => dashSpeed = value,
                    2.0f,
                    0.1f
                ).SetEase (Ease.Linear);
            }

            if (Input.GetButtonUp ("Fire2")) {
                dash = false;
                DOTween.To (
                    () => dashSpeed,
                    value => dashSpeed = value,
                    1.0f,
                    0.1f
                ).SetEase (Ease.Linear);
            }

            if (targetVel.magnitude > 0.1f) {

                Quaternion rotation = Quaternion.LookRotation (targetVel);

                /*var direction = rotation.y - transform.rotation.y;
                Debug.Log (direction);
                animator.SetFloat ("Direction", direction / 90.0f); */

                transform.rotation = Quaternion.Lerp (transform.rotation, rotation, Time.deltaTime * smoothRotation);

                animator.SetBool ("Dance", false);
            }

            animator.SetFloat ("Speed", targetVel.normalized.magnitude * dashSpeed);
            characterController.Move (targetVel.normalized * moveSpeed * dashSpeed);
        }
    }

}