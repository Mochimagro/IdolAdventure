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
    [SerializeField] private Flowchart flowchart;
    [SerializeField] private string talkTitle;
    [SerializeField] private DefaultPause defaultPause;

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
        flowchart.ExecuteBlock (talkTitle);
        animator.SetBool ("Talk", true);
        DanceStop ();
    }

    public void TalkEnd () {
        animator.SetBool ("Talk", false);
        DanceStart ();
    }

    public void DanceStop () {
        animator.SetBool ("Dance", false);
    }
    public void DanceStart () {
        animator.SetBool ("Dance", true);
    }

}