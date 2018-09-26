using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float playerSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        var vertical = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;
        transform.Translate(horizontal, vertical, 0);
    }
}
