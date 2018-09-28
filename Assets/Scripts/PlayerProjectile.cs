﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    public Transform player;

    // Speed of projectile
    public float projectileSpeed = 2;
    // Lifetime of projectile
    public float time = 1.5f;

    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {

        transform.position -= transform.position * projectileSpeed * Time.deltaTime;
        //Destroys projectile after t seconds
        Destroy(gameObject, time);
	}
}
