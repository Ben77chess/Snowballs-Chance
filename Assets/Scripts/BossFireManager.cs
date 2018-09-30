using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//in progress
public class BossFireManager : MonoBehaviour {
    public BossProjectileStandard standardBullet;
    public float singleFireSpeed, pulseSpeed; //seconds between single fire bullets
    // Use this for initialization
    void Start () {
        //StartCoroutine(singleFireRoutine(singleFireSpeed, 10));
        StartCoroutine(pulseRoutine(pulseSpeed, 2, 30));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator singleFireRoutine(float firerate, float bulletspeed) {
        standardBullet.projectileSpeed = bulletspeed;
        while (true) {
            Instantiate(standardBullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(firerate);
        }
    }

    public IEnumerator pulseRoutine(float firerate, float bulletspeed, int pulseBullets) {
        standardBullet.projectileSpeed = bulletspeed;
        float angleInc = 360 / pulseBullets;
        while (true) {
            for(int i = 0; i < pulseBullets; i++) {
                Instantiate(standardBullet, transform.position, Quaternion.AngleAxis(angleInc*i, Vector3.forward));
            }
            yield return new WaitForSeconds(firerate);
        }
    }
}
