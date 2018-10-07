using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Player movement speed
    public float playerSpeed;
    // Player projectile
    public PlayerProjectile projectile;
    //Crosshair texture
    public Texture2D crosshair;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public Transform boss;
    //For controling the rate of fire
    private float rate = 0.25f;
    private float last = 0;

	// Use this for initialization
	void Start () {
        //Initial spawn point of player

        transform.position = new Vector3(0, -3.5f, 0);
        //Cursor image replacement
        Cursor.SetCursor(crosshair, hotSpot, cursorMode);

    }
	
	// Update is called once per frame
	void Update () {

        //limits player to camera fov
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);


        //Have the player always face the mouse position
        FaceMouse();

        //Moves the player with the wasd or arrow keys
        var horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        var vertical = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;
        transform.Translate(horizontal, vertical, 0, Space.World);


        //fire control
        if (Input.GetMouseButton(0) && Time.time > rate + last)
        {
            last = Time.time;

            Fire();
        }
    }
    //projectile creation for the player bullets
    void Fire()
    {

        Instantiate(projectile, transform.position, Quaternion.identity);
    }
    //logic for the player to always face the mouse
    void FaceMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = dir;
    }


}
