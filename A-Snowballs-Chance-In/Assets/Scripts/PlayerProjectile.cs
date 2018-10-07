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
        //Gets the mouse position and returns a normalized vector
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        mousePosition.z = 0;
        directionVector = (mousePosition - transform.position).normalized;

    }
	
	// Update is called once per frame
	void Update () {
        //transform.position = transform.position + Camera.main.transform.forward * projectileSpeed * Time.deltaTime;
        //set bomb at player position, could be another game mechanic later

        //Shoots projectile at mouse position
        transform.Translate(directionVector * projectileSpeed * Time.deltaTime);

        //transform.position = Vector2.MoveTowards(transform.position, mousePosition, projectileSpeed);
        //goes to mouse position, then stops there, good for another game mechanic?

        //Destroys projectile after t seconds
        Destroy(gameObject, time);
	}
}
