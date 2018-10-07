using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager uiManager;
    public Image bossHealth;
    public PlayerHealthUIManager playerHealth;
    public int bossesDefeated = 0;
    public Text bossHealthText;


    void Awake() {
        //Add a bosses defeated counter to the UI to track player progress
        bossesDefeated = 0;
        uiManager = this;
        bossHealthText.text = "Bosses Defeated: " + bossesDefeated;
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void updateBossHealthUI(float current, float max) {
        //Displays the boss' health
        float fill = current / max;
        bossHealth.fillAmount = fill;
        bossHealthText.text = "Bosses Defeated: " + bossesDefeated;
    }
}
