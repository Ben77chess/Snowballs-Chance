using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager uiManager;
    public Image bossHealth;
    public PlayerHealthUIManager playerHealth;
    public int bossesDefeated = 0;


    void Awake() {
        bossesDefeated = 0;
        uiManager = this;
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void updateBossHealthUI(float current, float max) {
        float fill = current / max;
        bossHealth.fillAmount = fill;
    }
}
