using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour {

    public AudioClip[] hitSounds;

    private AudioSource source;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EnemyBullet")
        {
            //play a random hit sound from a group upon impact
            source.PlayOneShot(hitSounds[UnityEngine.Random.Range(0, hitSounds.Length)]);
        }
    }
}
