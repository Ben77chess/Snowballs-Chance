using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileStandard : BossProjectile {
    
    // Speed of projectile
    // Lifetime of projectile
    // Use this for initialization

    void Start () {
        projectileSpeed = 5;
        time = 30;
        maxScale = 2;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.right * projectileSpeed * Time.deltaTime;
        //Destroys projectile after t seconds
        //transform.scale.x
        Destroy(gameObject, time);
    }
}
