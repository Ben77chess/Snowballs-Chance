using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//in progress
public class BossFireManager : MonoBehaviour {
    public BossProjectile standardBullet;
    public BossProjectile[] bullets;
    public float singleFireSpeed, pulseSpeed; //seconds between single fire bullets

    private Action[] strategies;
    System.Random rand = new System.Random();
    // Use this for initialization
    void Start () {
        strategies = new Action[] { slowPulseFastSingle, fastPulseSlowSingle, opposingSpirals, bulletCloud };
        int i = rand.Next(strategies.Length);
        int j = rand.Next(bullets.Length);
        Debug.Log("Strat no: " + i);
        Debug.Log("Bullet no: " + j);
        strategies[i]();
        standardBullet = bullets[j];


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

    public void opposingSpirals() {
        StartCoroutine(spiralCounterClockWiseRoutine(2, 10, 12, .11f));
        StartCoroutine(spiralClockWiseRoutine(2, 10, 12, .1f));
    }

    public void bulletCloud() {
        StartCoroutine(randomRoutine(.2f, 20, 5, 1, 180));
    }

    //Fire Patterns

   

    //public IEnumerator bomb(float bombrate)
    //{
        //transform.position = transform.position + Camera.main.transform.forward * projectileSpeed * Time.deltaTime;
        //set bomb at player pos
    //}

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

    public IEnumerator spiralCounterClockWiseRoutine(float firerate, float bulletspeed, int pulseBullets, float spiralDelay) {
        standardBullet.projectileSpeed = bulletspeed;
        float angleInc = 360 / pulseBullets;
        while (true) {
            for (int i = 0; i < pulseBullets; i++) {
                Instantiate(standardBullet, transform.position, Quaternion.AngleAxis(angleInc * i, Vector3.forward));
                yield return new WaitForSeconds(spiralDelay);
            }
            yield return new WaitForSeconds(firerate);
        }
    }

    public IEnumerator spiralClockWiseRoutine(float firerate, float bulletspeed, int pulseBullets, float spiralDelay) {
        standardBullet.projectileSpeed = bulletspeed;
        float angleInc = 360 / pulseBullets;
        while (true) {
            for (int i = 0; i < pulseBullets; i++) {
                Instantiate(standardBullet, transform.position, Quaternion.AngleAxis(angleInc * -i, Vector3.forward));
                yield return new WaitForSeconds(spiralDelay);
            }
            yield return new WaitForSeconds(firerate);
        }
    }

    public IEnumerator randomRoutine(float maxfirerate, float maxbulletspeed, float durationOfEffect, float timeBetweenEffects, int angleOfEffect) { //Super proud of this one
        float angle;
        float currentTime;
        while (true) {
            currentTime = 0;
            float startTime = Time.time;
            while (currentTime < durationOfEffect) {
                currentTime = Time.time - startTime;
                standardBullet.projectileSpeed = (float)rand.NextDouble() * maxbulletspeed;
                angle = rand.Next(angleOfEffect);
                angle = angle - angleOfEffect/2; //allows us to change to + or - value around transform.right
                Instantiate(standardBullet, transform.position, transform.rotation * Quaternion.AngleAxis(angle, Vector3.forward)); //friggin quaternions
                yield return new WaitForSeconds((float)rand.NextDouble() * maxfirerate);
            }
            yield return new WaitForSeconds(timeBetweenEffects);
        }
    }
}
