using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour {
    public float lifetime;
	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyAfter(lifetime));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //Adds hit affect for the boss when hit by the player projectile
    IEnumerator DestroyAfter(float lifetime) {
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);
    }
}
