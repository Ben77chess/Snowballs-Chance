using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager uiManager;
    public Image bossHealth;
    public PlayerHealthUIManager playerHealth;

	// Use this for initialization
	void Start () {
        uiManager = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void updateBossHealthUI(float current, float max) {
        float fill = current / max;
        bossHealth.fillAmount = fill;
    }
}
