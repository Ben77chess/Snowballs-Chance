using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealthManager : MonoBehaviour {

    public int health;
    private int maxHealth;
    public ParticleSystem hiteffect;
	// Use this for initialization
	void Start () {
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
            Die();
        }
    }

    public void Die() {
        //further death logic when we decide what to do
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

