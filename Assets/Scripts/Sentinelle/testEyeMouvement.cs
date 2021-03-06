﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEyeMouvement : MonoBehaviour
{
    public Eye eye;
    public Light retine; 

    // Use this for initialization
    void Start() {
        StartCoroutine(EyeMoveScript());
    }

    // Update is called once per frame
    void Update() {
        if(eye.detectPlayer()){
            retine.color = Color.green;
        }else{
            retine.color = Color.red;
        }
    }

    IEnumerator EyeMoveScript() {
        eye.MoveEye(0, -20);
        while (eye.isMoving())
        {
            yield return new WaitForSeconds(0.1f);
        }
        eye.MoveEye(20, 0);
        while (true)
        {
            while (eye.isMoving())
            {
                yield return new WaitForSeconds(0.1f);
            }
            eye.MoveEye(-40, 0);
            while (eye.isMoving())
            {
                yield return new WaitForSeconds(0.1f);
            }
            eye.MoveEye(40, 0);
        }
    }

}