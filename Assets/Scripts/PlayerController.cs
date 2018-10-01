using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Player movement speed
    public float playerSpeed;
    // Player projectile
    public PlayerProjectile projectile;

    public Texture2D crosshair;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public Transform boss;

    private float rate = 0.25f;
    private float last = 0;

	// Use this for initialization
	void Start () {
        //Initial spawn point of player

        transform.position = new Vector3(0, -3.5f, 0);

        Cursor.SetCursor(crosshair, hotSpot, cursorMode);

    }
	
	// Update is called once per frame
	void Update () {

        //limits player to camera fov
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);



        FaceMouse();


        var horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        var vertical = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;   


        transform.Translate(horizontal, vertical, 0, Space.World);


        
        if (Input.GetMouseButton(0) && Time.time > rate + last)
        {
            last = Time.time;

            Fire();
        }
    }

    void Fire()
    {

        Instantiate(projectile, transform.position, Quaternion.identity);
    }

    void FaceMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = dir;
    }


}
