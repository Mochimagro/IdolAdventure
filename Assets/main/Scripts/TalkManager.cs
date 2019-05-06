using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

[RequireComponent (typeof (PlayerController))]
public class TalkManager : MonoBehaviour {

    private bool isTalking = false;
    [SerializeField] private string talkTitle;
    [SerializeField] private Flowchart defaultChart;
    private List<NPCharacterContoller> targetCharacters = new List<NPCharacterContoller> ();
    private PlayerController playerController;

    private void Start () {
        playerController = GetComponent<PlayerController> ();
    }

    private void Update () {
        if (Input.GetButtonDown ("Fire1")) {
            TalkAction ();
        }
    }

    /// <summary>
    /// アクションボタンを押したらプレイヤーの状況を見て判定
    /// </summary>
    public void TalkAction () {
        if (!isTalking) {
            if (targetCharacters.Count == 0) {
                TalkStart ();
            } else {
                TalkStart (targetCharacters[0].flowchart);
            }
        }
    }

    public void TalkStart () {
        TalkStart (defaultChart);
    }

    public void TalkStart (Flowchart targetFlowchart) {
        isTalking = true;
        targetFlowchart.ExecuteBlock (talkTitle);
        playerController.isTalking = true;
    }

    public void TalkEnd () {
        isTalking = false;
        playerController.isTalking = false;
    }

    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("NPC")) {
            targetCharacters.Add (other.gameObject.GetComponent<NPCharacterContoller> ());
        }
    }

    private void OnTriggerExit (Collider other) {
        if (other.gameObject.CompareTag ("NPC")) {
            targetCharacters.Remove (other.gameObject.GetComponent<NPCharacterContoller> ());
        }
    }

}