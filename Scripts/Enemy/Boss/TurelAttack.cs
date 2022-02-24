using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurelAttack : MonoBehaviour
{
    [Header("Характеристики снарядов")]
    public float speed = 10f;
    public int score = 100;
    public float timeProjectile = 0.7f;

    public GameObject projectileEnemy;
    public float projectileSpeed = 5;
    public Vector2 pos
    {
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }

    private BoundsCheck bndCheck;

    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
        Invoke("FireEnemy", timeProjectile); // Вызываем функцию по установленному времени
    }

    void Update()
    {
        if (bndCheck != null && bndCheck.offRight)
        {
            Destroy(gameObject);
        }
    }

    void FireEnemy()
    {
        GameObject projGO = Instantiate<GameObject>(projectileEnemy);
        projGO.transform.position = transform.position;
        Rigidbody2D rigidB = projGO.GetComponent<Rigidbody2D>();
        rigidB.velocity = Vector2.down * projectileSpeed;
        Invoke("FireEnemy", timeProjectile);
    }

    /*private void OnTriggerEnter2D(Collider2D coll2D)
    {
        GameObject gO = coll2D.gameObject;

        if (gO.tag == "ProjectileHero") // Противник сталкивается со снарядом игрока
        {
            Destroy(gO);
            Destroy(gameObject);

        }
    }*/
}
