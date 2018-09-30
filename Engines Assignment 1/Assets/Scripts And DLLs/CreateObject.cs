using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputHandler;

public class CreateHorse : Command
{
    GameObject dummy;
    public override void Execute(GameObject obj)
    {
        dummy = Instantiate(obj, spawnLocation, spawnRotation) as GameObject;
    }
}

public class CreateObject : MonoBehaviour {

    public GameObject toCreate;


	// Use this for initialization
	void Start () {	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
