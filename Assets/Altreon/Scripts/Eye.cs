using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour {

    private float angleXRemaining;
    private int angleXDir;
    private float angleYRemaining;
    private int angleYDir;

    public float speed;
    public float tolerance;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (angleXRemaining - tolerance > 0) {
            float angleRotate = speed * Time.deltaTime * angleXRemaining;
            transform.RotateAround(transform.parent.transform.position, transform.up * -1, angleRotate * angleXDir);
            angleXRemaining -= angleRotate;
        }

        if (angleYRemaining - tolerance > 0) {
            float angleRotate = speed * Time.deltaTime * angleYRemaining;
            transform.RotateAround(transform.parent.transform.position, transform.forward, angleRotate * angleYDir);
            angleYRemaining -= angleRotate;
        }

    }

    public void MoveEye (float angleX, float angleY) {
        if (angleX > 0) {
            angleXDir = 1;
        }
        else {
            angleXDir = -1;
        }
        angleXRemaining = angleX * angleXDir;

        if (angleY > 0) {
            angleYDir = 1;
        }
        else {
            angleYDir = -1;
        }
        angleYRemaining = angleY * angleYDir;

    }

    public bool isMoving() {
        if (angleXRemaining - tolerance > 0 || angleYRemaining - tolerance > 0) {
            return true;
        } else {
            return false;
        }
    }
}
