using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public Transform posCam;
    public Transform player;

    private Transform[] pos;
    private bool follow;

	// Use this for initialization
	void Start () {
		pos = new Transform[3];
        for (int i = 0; i < posCam.childCount; i++) {
		    pos[i] = posCam.GetChild(i);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeCamPosition(int id){
        transform.position = pos[id].position;
        transform.rotation = pos[id].rotation;
        follow = false;
    }
    
    public void camFollowPlayer (float distance, Vector3 rotation) {
        transform.position = new Vector3(player.position.x, player.position.y + distance, player.position.z);
        transform.RotateAround(player.position, Vector3.right, rotation.x);
        transform.RotateAround(player.position, Vector3.up, rotation.y);
        transform.RotateAround(player.position, Vector3.forward, rotation.z);
        transform.LookAt(player);
        follow = true;
    }

    public bool isFollow () {
        return follow;
    }
}
