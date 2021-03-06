﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_controller : MonoBehaviour
{
    public Animator animator;
    public ParticleSystem particle;
    public ParticleSystem blood;
    public AudioSource audioSource;
    public AudioClip death;
    // public GameObject mushroom;

    //private Transform mushroom_t;
    // Start is called before the first frame update
    void Start()
    {
        /// mushroom_t = mushroom.transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        //blood.Play();
        audioSource.mute = !GameManager.soundEnabled;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("CRUSHED");
        InanimateObject obj = collision.gameObject.GetComponent<InanimateObject>();
        //animator.SetTrigger("die");
        if (obj && obj.IsFalling())
        {

           // Vector3 scale = mushroom_t.localScale;
            //Debug.Log(scale);
           // scale.y /= 10;
            //Debug.Log("new:  "+scale);
            //mushroom.transform.localScale = scale;
           // mushroom.transform.localPosition += new Vector3(0f,mushroom_t.localPosition.x,0f);
            

            animator.SetTrigger("die");
            audioSource.Stop();
            particle.Stop();
            audioSource.volume = 1f;
            audioSource.PlayOneShot(death);
            blood.Play();
            
            Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>());
        }
    }
}
