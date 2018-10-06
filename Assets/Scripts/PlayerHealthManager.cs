using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//feel free to change this if you want it to be different
public class PlayerHealthManager : MonoBehaviour {

    public int health = 3;
    private bool immune = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "EnemyBullet") {
            decreaseHealth(1);
            Destroy(col.gameObject);
            //col.gameObject.Die(); Destroy bullet, explosion fx etc.
        }
    }

    public void decreaseHealth(int damage) {
        if (!immune) {
            health -= damage;
            UIManager.uiManager.playerHealth.UpdateLives(health);
            if (health <= 0) {
                Die();
            }
            else {
                StartCoroutine(Immune(2));
            }
        }
        
    }

    public void Die() {
        //further death logic when we decide what to do
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator Immune(float immuneTime) {
        immune = true;
        float startTime = Time.time;
        float flashes = 10;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        while (Time.time < startTime + immuneTime) {
            sr.color = Color.red;
            yield return new WaitForSeconds(immuneTime / (flashes * 2));
            sr.color = Color.white;
            yield return new WaitForSeconds(immuneTime / (flashes * 2));
        }
        immune = false;
    }
}
