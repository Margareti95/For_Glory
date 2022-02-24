using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particale : MonoBehaviour
{
    public GameObject particaleEffect;

    private Animator shakeCam;

    private void Start()
    {
        shakeCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D coll2D)
    {
        GameObject gO = coll2D.gameObject;

        if(gO.tag == "ProjectileHero")
        {
            shakeCam.SetTrigger("Shake");
            Instantiate(particaleEffect, transform.position, Quaternion.identity);
            Destroy(gO); // Уничтожение объекта "Enemy"
            Destroy(gameObject);
        }
    }
}
