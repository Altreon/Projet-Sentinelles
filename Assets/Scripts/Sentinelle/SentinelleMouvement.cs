using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelleMouvement : MonoBehaviour {

    public Transform positionGroup;
    public float speed;
    public float tolerance;

    private Transform[] pos;
    public int currentPos;
    private List<int> posToReach;
    private float distance;
    private float startTime;

	// Use this for initialization
	void Start () {
		pos = new Transform[positionGroup.childCount];
        for (int i = 0; i < positionGroup.childCount; i++) {
		    pos[i] = positionGroup.GetChild(i);
        }
        posToReach = new List<int>();
        currentPos = 0;
    }

    public void moveToPoint(int num) {
        int p = 1;
        if(num < currentPos){
            p = -1;
        }
        for (int i = 1; i <= (num - currentPos) * p; i++){
            posToReach.Add(currentPos + i * p);
        }

        distance = Vector3.Distance(transform.position, pos[posToReach[0]].position);
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		if(posToReach.Count != 0){
            move();
        }
    }

    private void move() {
        float mouvementSpeed = ((Time.time - startTime) * speed) / distance;
        transform.position = Vector3.Lerp(transform.position, pos[posToReach[0]].position, mouvementSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, pos[posToReach[0]].rotation, mouvementSpeed);

        if(Vector3.Distance(transform.position, pos[posToReach[0]].position) <= tolerance){
            currentPos = posToReach[0];
            posToReach.RemoveAt(0);

            if(posToReach.Count != 0){
                distance = Vector3.Distance(transform.position, pos[posToReach[0]].position);
                startTime = Time.time;
            }
        }
    }
}
