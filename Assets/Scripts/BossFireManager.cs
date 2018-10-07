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
        //Choose from strategies randomly
        strategies = new Action[] { densePulse, slowPulseFastSingle, fastPulseSlowSingle, opposingSpirals, bulletCloud, threePulse, spiralSpew, hellSphere }; // slowPulseFastSingle, fastPulseSlowSingle, opposingSpirals, bulletCloud, ThreePulse, spiralSpew,
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
        StartCoroutine(singleFireRoutine(.2f, 15));
        StartCoroutine(pulseRoutine(5, 4, 16));
    }

    public void fastPulseSlowSingle() {
        StartCoroutine(singleFireRoutine(1.5f, 25));
        StartCoroutine(pulseRoutine(1, 15, 15));
    }

    public void opposingSpirals() {
        StartCoroutine(spiralCounterClockWiseRoutine(2, 15, 12, .11f));
        StartCoroutine(spiralClockWiseRoutine(2, 15, 12, .1f));
        StartCoroutine(spiralCounterClockWiseRoutine(2.5f, 20, 16, .1f));
    }

    public void bulletCloud() {
        StartCoroutine(randomRoutine(.2f, 30, 5, 1, 180));
    }

    public void threePulse() {
        StartCoroutine(pulseRoutine(.5f, 10, 4));
        StartCoroutine(pulseRoutine(1.75f, 15, 12));
        StartCoroutine(pulseRoutine(2.5f, 8, 16));
    }

    public void spiralSpew() {
        StartCoroutine(randomRoutine(.2f, 30, 3, 2, 45));
        StartCoroutine(spiralClockWiseRoutine(1, 20, 20, .15f));
    }

    public void hellSphere() {
        StartCoroutine(randomRoutine(.1f, 40, 4, 0, 360));
    }

    public void densePulse() {
        StartCoroutine(randomRoutine(.4f, 20, 4, 0, 360));
        StartCoroutine(pulseRoutine(.79f, 10, 12));
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
