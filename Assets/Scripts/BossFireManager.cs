using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//in progress
public class BossFireManager : MonoBehaviour {
    public BossProjectileStandard standardBullet;
    public float singleFireSpeed; //seconds between single fire bullets
    // Use this for initialization
    void Start () {
        StartCoroutine(singleFireRoutine(singleFireSpeed));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator singleFireRoutine(float firerate) {
        while (true) {
            Instantiate(standardBullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(firerate);
        }
    }
}
