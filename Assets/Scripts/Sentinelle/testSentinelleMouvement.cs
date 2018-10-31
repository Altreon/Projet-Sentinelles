using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSentinelleMouvement : MonoBehaviour {

    public SentinelleMouvement mouvement;
    public bool useTest;

    private int pos;

	// Use this for initialization
	void Start () {
        pos = 0;
		if(useTest){
            StartCoroutine(SentinelleMovementScript());
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator SentinelleMovementScript () {
        yield return new WaitForSeconds(2);
        mouvement.moveToPoint(1);
        yield return new WaitForSeconds(3);
        mouvement.moveToPoint(2);
        yield return new WaitForSeconds(3);
        mouvement.moveToPoint(3);
        yield return new WaitForSeconds(3);
        mouvement.moveToPoint(4);
        yield return new WaitForSeconds(3);
        mouvement.moveToPoint(5);
        yield return new WaitForSeconds(3);
        mouvement.moveToPoint(6);
        yield return new WaitForSeconds(4);
        mouvement.moveToPoint(0);
    }
}
