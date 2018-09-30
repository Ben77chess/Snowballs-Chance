using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//in progress
public class BossFireManager : MonoBehaviour {
    public BossProjectileStandard standardBullet;
    public float singleFireSpeed, pulseSpeed; //seconds between single fire bullets

    private Action[] strategies;
    System.Random rand = new System.Random();
    // Use this for initialization
    void Start () {
        strategies = new Action[] { slowPulseFastSingle, fastPulseSlowSingle};
        int i = rand.Next(strategies.Length);
        strategies[i]();


        //StartCoroutine(singleFireRoutine(singleFireSpeed, 10));
        //StartCoroutine(pulseRoutine(pulseSpeed, 2, 30));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Strategies
    public void slowPulseFastSingle() {
        StartCoroutine(singleFireRoutine(.2f, 10));
        StartCoroutine(pulseRoutine(5, 3, 8));
    }

    public void fastPulseSlowSingle() {
        StartCoroutine(singleFireRoutine(2, 5));
        StartCoroutine(pulseRoutine(1, 6, 12));
    }

    //Fire Patterns

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
