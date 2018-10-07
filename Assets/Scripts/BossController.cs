using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public PlayerController player;
    public float movementSpeed = 1;
    private System.Random rand;
	// Use this for initialization
	void Start () {
        //Initial Boss position
        StopAllCoroutines();
        movementSpeed = movementSpeed + UIManager.uiManager.bossesDefeated/4f; //again WIP
        transform.position = new Vector3(0, 3.5f, 0);

    }
	
	// Update is called once per frame
	void Update () {
        //Have the boss follow and face the player
        transform.right = player.transform.position - transform.position;
        transform.Translate(new Vector3(Math.Abs(transform.right.normalized.x * movementSpeed * Time.deltaTime), transform.right.normalized.y * movementSpeed * Time.deltaTime, 0));
	}

    
}
