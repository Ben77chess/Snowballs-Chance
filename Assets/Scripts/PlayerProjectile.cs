using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    // Speed of projectile
    public float projectileSpeed;
    // Lifetime of projectile
    public float time;
    // Direction of projectile
    public Vector2 direction = new Vector2(0, 1);

    // Use this for initialization
    void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {

        transform.position += new Vector3(direction.x, direction.y, 0) * projectileSpeed * Time.deltaTime;
        time -= Time.deltaTime;
        if (time < 0)
        {
            Destroy(gameObject);
        }

	}
}
