using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileGrow : BossProjectile {

	// Use this for initialization
	void Start () {
        maxScale = 2;
        time = 7;
        projectileSpeed = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localScale.x < maxScale) {
            transform.localScale += new Vector3(Time.deltaTime*.1f*projectileSpeed, Time.deltaTime*.2f*projectileSpeed, 0); //If they move faster they grow faster and v.v.
        }
        transform.position += transform.right * projectileSpeed * Time.deltaTime;
        Destroy(gameObject, time);
    }
}
