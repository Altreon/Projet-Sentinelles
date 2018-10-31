using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMoveCam : MonoBehaviour {

    public new Camera camera;
    public int distance;
    public Vector3 rotation;

    private int currentPos;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {
            currentPos++;
            if(currentPos > 2){
                currentPos = 0;
            }
           camera.changeCamPosition(currentPos);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            camera.camFollowPlayer(distance, rotation);
        }

        if(camera.isFollow()){
            camera.camFollowPlayer(distance, rotation);
        }
	}
}
