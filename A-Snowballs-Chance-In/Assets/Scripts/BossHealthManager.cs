using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class BossHealthManager : MonoBehaviour {

    public int health;
    public int maxHealth = 10;
    public ParticleSystem hiteffect;




	// Use this for initialization
	void Start () {
        //health = maxHealth * Math.Max(UIManager.uiManager.bossesDefeated, 1) + rand.Next(10) * UIManager.uiManager.bossesDefeated; // 1st, maxHealth 2nd maxHealth + 0-9, 3rd maxHelath * 2 + 0-18(evens), 4th 3*maxHealth + 0-27(threes) ...
        health = maxHealth + 6 * UIManager.uiManager.bossesDefeated; //WIP for balance, but the idea is there.
        maxHealth = health;

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col) {
        //decrease boss health when hit by the player bullet, destroys the projectile
        if (col.gameObject.tag == "FriendlyBullet") {

            decreaseHealth(1);
            Instantiate(hiteffect, col.gameObject.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            //col.gameObject.Die(); Destroy bullet, explosion fx etc.
        }
    }
    //Health manager
    public void decreaseHealth(int damage) {
        health -= damage;
        UIManager.uiManager.updateBossHealthUI(health, maxHealth);
        if (health <= 0) {
            StartCoroutine(Die());
        }
    }
    
    public IEnumerator Die() {
        UIManager.uiManager.bossesDefeated += 1;
        Time.timeScale = 0; //pause
        health = maxHealth;
        UIManager.uiManager.updateBossHealthUI(health, maxHealth); //refill health bar UI for clarity
        Destroy(this.GetComponent<SpriteRenderer>()); //destroy old boss sprite for clarity
        //New color for new boss instantiation
        GameObject newBoss = Instantiate(this.gameObject, new Vector3(0, 0, 0), Quaternion.identity);
        Renderer rend = newBoss.GetComponent<SpriteRenderer>();
        rend.material.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        //destroys all projectiles upon boss defeat
        GameObject[] eBullet = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach (GameObject e in eBullet)
        {
            Destroy(e);
        }
        GameObject[] bullet = GameObject.FindGameObjectsWithTag("FriendlyBullet");
        foreach (GameObject bul in bullet)
        {
            Destroy(bul);
        }

        yield return new WaitForSecondsRealtime(3); //have to use realtime because timeScale = 0
        Time.timeScale = 1;
        Destroy(this.gameObject);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

