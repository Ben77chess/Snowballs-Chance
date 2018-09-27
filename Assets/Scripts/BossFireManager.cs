using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//in progress
public class BossFireManager : MonoBehaviour {
    public PlayerProjectile standardBullet;
    // Use this for initialization
    void Start () {
        StartCoroutine(singleFireRoutine());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator singleFireRoutine() {
        while (true) {
            Instantiate(standardBullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }
}
