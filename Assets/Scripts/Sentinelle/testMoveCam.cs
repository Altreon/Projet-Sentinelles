using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMoveCam : MonoBehaviour {
    public Transform posCam;

    private Transform[] pos;

    private int currentPos;

	// Use this for initialization
	void Start () {
        pos = new Transform[3];
        for (int i = 0; i < posCam.childCount; i++) {
		    pos[i] = posCam.GetChild(i);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {
            currentPos++;
            if(currentPos > 2){
                currentPos = 0;
            }
            changeCamPosition(currentPos);
        }
	}

    public void changeCamPosition(int id){
        transform.position = pos[id].position;
        transform.rotation = pos[id].rotation;
    }   
}
