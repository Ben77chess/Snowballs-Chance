﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Switch from the start screen to the game scene
        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("Boss");
        }
	}
}