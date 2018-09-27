using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    // Speed of projectile
    public float projectileSpeed = 2;
    // Lifetime of projectile
    public float time = 1.5f;
    // Direction of projectile
    public Vector2 direction = new Vector2(0, 1);

    // Use this for initialization
    void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(transform.right.x, transform.right.z, 0));
        //Destroys projectile after t seconds
        Destroy(gameObject, time);
	}
}
