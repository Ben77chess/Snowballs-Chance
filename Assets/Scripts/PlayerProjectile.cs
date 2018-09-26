using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    // Speed of projectile
    public float projectileSpeed = 2;
    // Lifetime of projectile
    public float time = 1.5f;
    // Direction of projectile
    public Vector2 direction = new Vector2(0, 0);

    // Use this for initialization
    void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(direction.x, direction.y, 0) * projectileSpeed * Time.deltaTime;
        //Destroys projectile after t seconds
        Destroy(gameObject, time);
	}
}
