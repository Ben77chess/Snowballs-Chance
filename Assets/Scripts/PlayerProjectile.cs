using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    public Transform player;

    // Speed of projectile
    public float projectileSpeed = 2;
    // Lifetime of projectile
    public float time = 1.5f;

    private Vector3 mousePosition;
    private Vector2 directionVector;

    // Use this for initialization
    void Start () {

        mousePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        mousePosition.z = 0;
        directionVector = (mousePosition - transform.position).normalized;

    }
	
	// Update is called once per frame
	void Update () {



        //transform.position = transform.position + Camera.main.transform.forward * projectileSpeed * Time.deltaTime;
        //set bomb at player pos

        transform.Translate(directionVector * projectileSpeed * Time.deltaTime);


        //transform.position = Vector2.MoveTowards(transform.position, mousePosition, projectileSpeed);
        //goes to mouse position, then stops there


        //transform.position += transform.position * projectileSpeed * Time.deltaTime;

        //transform.position += transform.up * projectileSpeed * Time.deltaTime;

        //Destroys projectile after t seconds
        Destroy(gameObject, time);
	}
}
