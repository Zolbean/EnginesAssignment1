using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {
    Vector3 rDir;
    float cdTime;
    public int speed = 10;

    // Use this for initialization
    void Start () {
        rDir = new Vector3(Random.Range(-100, 101), 0, Random.Range(-100, 100));
        rDir = rDir / 100;
        cdTime = Random.Range(1, 5);
        //print(cdTime);
        //print(rDir);
    }
	
	// Update is called once per frame
	void Update () {
        cdTime = cdTime - Time.deltaTime;
        if (cdTime <= 0)
        {
            rDir = new Vector3(Random.Range(-100, 101), 0, Random.Range(-100, 100));
            rDir = rDir / 100;
            cdTime = Random.Range(1, 5);
            //print(cdTime);
            //print(rDir);
        }
        GetComponent<Rigidbody>().velocity = rDir * speed;

        gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(rDir.x, rDir.y, rDir.z)*-1);
    }
}
