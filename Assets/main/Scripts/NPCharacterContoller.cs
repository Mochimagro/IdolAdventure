using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class NPCharacterContoller : MonoBehaviour {

    [System.Serializable]
    public enum DefaultPause {
        Idle,
        Dance,
        Talk,

    }

    [SerializeField] private Animator animator;
    [SerializeField] public Flowchart flowchart;
    [SerializeField] private DefaultPause defaultPause;

    public virtual string NPC_Motion {
        set {
            animator.SetBool (value, true);
        }
    }

    void Start () {
        animator.speed = 1.5f;
        SetDefaultPause ();
    }

    void Update () {

    }

    private void SetDefaultPause () {
        switch (defaultPause) {
            case DefaultPause.Idle:
                return;

            case DefaultPause.Talk:
                animator.SetBool ("Talk", true);
                return;

            case DefaultPause.Dance:
                animator.SetBool ("Dance", true);
                return;
        }
    }

    public void TalkStart () {
        Debug.Log ("TALK");
        animator.SetBool ("Talk", true);
    }

    public void TalkEnd () {
        animator.SetBool ("Talk", false);
    }
}