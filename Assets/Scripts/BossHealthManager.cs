using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class BossHealthManager : MonoBehaviour {

    public int health;
    public int maxHealth = 10;
    public ParticleSystem hiteffect;
    private System.Random rand;
	// Use this for initialization
	void Start () {
        //health = maxHealth * Math.Max(UIManager.uiManager.bossesDefeated, 1) + rand.Next(10) * UIManager.uiManager.bossesDefeated; // 1st, maxHealth 2nd maxHealth + 0-9, 3rd maxHelath * 2 + 0-18(evens), 4th 3*maxHealth + 0-27(threes) ...
        health = maxHealth * Math.Max(UIManager.uiManager.bossesDefeated,1); //WIP for balance, but the idea is there.
        maxHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "FriendlyBullet") {
            decreaseHealth(1);
            Instantiate(hiteffect, col.gameObject.transform.position, Quaternion.identity);
            //col.gameObject.Die(); Destroy bullet, explosion fx etc.
        }
    }

    public void decreaseHealth(int damage) {
        health -= damage;
        UIManager.uiManager.updateBossHealthUI(health, maxHealth);
        if (health <= 0) {
            StartCoroutine(Die());
        }
    }

    public IEnumerator Die() {
        //further death logic when we decide what to do
        UIManager.uiManager.bossesDefeated += 1;
        Time.timeScale = 0;
        health = maxHealth;
        UIManager.uiManager.updateBossHealthUI(health, maxHealth);
        Destroy(this.GetComponent<SpriteRenderer>()); //this will break when Jonah detaches the SR.
        Instantiate(this.gameObject, new Vector3(0, 0, 0), Quaternion.identity);
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        Destroy(this.gameObject);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

