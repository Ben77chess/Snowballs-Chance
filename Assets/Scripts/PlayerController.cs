using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Player movement speed
    public float playerSpeed;
    // Player projectile
    public GameObject projectile;
    // Spawn of projectile
    public Transform projectileSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        var vertical = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;
        transform.Translate(horizontal, vertical, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(projectile, transform.position + Vector3.up, Quaternion.identity);

    }
}
