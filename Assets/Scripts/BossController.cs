using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public PlayerController player;
    public float movementSpeed;
	// Use this for initialization
	void Start () {
        //Initial Boss position
        transform.position = new Vector3(0, 3.5f, 0);

    }
	
	// Update is called once per frame
	void Update () {
        transform.right = player.transform.position - transform.position;
        transform.Translate(new Vector3(Math.Abs(transform.right.normalized.x * movementSpeed * Time.deltaTime), transform.right.normalized.y * movementSpeed * Time.deltaTime, 0));
	}

    
}
