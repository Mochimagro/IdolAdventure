﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotationCamera : MonoBehaviour {
    private void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            GetComponent<Animator> ().SetFloat ("PlaySpeed", 1.0f);
        }
    }
}