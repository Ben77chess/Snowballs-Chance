using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Player movement speed
    public float playerSpeed;
    // Player projectile
    public PlayerProjectile projectile;

    public Transform boss;

    private float rate = 0.25f;
    private float last = 0;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        var horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        var vertical = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;



        transform.Translate(horizontal, vertical, 0);


        


        if (Input.GetButton("Jump") && Time.time > rate + last)
        {
            last = Time.time;
            Fire();
        }
    }

    void Fire()
    {
        //Instantiate(projectile, transform.position, transform.rotation);
        Instantiate(projectile, transform.position + Vector3.up, Quaternion.identity);
    }
    /*
    void orientPlayer()
    {
        Vector3 direction = boss.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    */
}
