using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour {

    private float angleXRemaining;
    private int angleXDir;
    private float angleYRemaining;
    private int angleYDir;

	public Player player;
    public float speed;
    public float tolerance;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
		//Mouvement de l'oeil
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
		
		//Détéction du joueur
        debugVector();
		if (detectPlayer()){
			//Debug.Log("Game Over");
		}else{
			//Debug.Log("En vie!");
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
	
	public bool detectPlayer () {
		if((angleBetweenVector(transform.right, player.transform.position - transform.position)) * (360/Mathf.PI) < 50) {
             RaycastHit obstacle;
            if (Physics.Raycast(transform.position, player.transform.position - transform.position, out obstacle) && obstacle.collider.tag == "Player") {
                return true;
            }else{
                return false;
            }
		}else{
			return false;
		}
	}
	
	private double angleBetweenVector(Vector3 v1, Vector3 v2){
		return Mathf.Acos((float)(Vector3.Dot(v1, v2) / (norme(v1) * norme(v2))));
	}
	
	private double norme (Vector3 vect) {
		return Mathf.Sqrt(Mathf.Pow(vect.x,2) + Mathf.Pow(vect.y,2) + Mathf.Pow(vect.z,2));
	}

    private void debugVector () {
        Debug.DrawLine(Vector3.zero, transform.right * 10, Color.red, 2.5f);
        Debug.DrawLine(Vector3.zero, player.transform.position - transform.position, Color.green, 2.5f);
        Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.yellow);
    }
}
