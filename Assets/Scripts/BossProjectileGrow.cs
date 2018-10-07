using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileGrow : BossProjectile {

	// Use this for initialization
	void Start () {
        maxScale = 2;
        time = 25;
        projectileSpeed = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localScale.x < maxScale) {
            transform.localScale += new Vector3(Time.deltaTime*.05f*projectileSpeed, Time.deltaTime*.05f*projectileSpeed, 0); //If they move faster they grow faster and v.v.
        }
        transform.position += transform.right * projectileSpeed * Time.deltaTime;
        Destroy(gameObject, time);
    }
}
