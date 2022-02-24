using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
        Invoke("FireEnemy", timeProjectile); // Вызываем каждую секунду данную функцию
    }

    void Update()
    {

        Move();

        if (bndCheck != null && bndCheck.offRight)
        {
            Destroy(gameObject);
        }
    }

    public virtual void Move()
    {
        // Движение по оси икс слева-направо
        Vector2 tempPos = pos;
        tempPos.x += speed * Time.deltaTime;
        pos = tempPos;
    }

        void FireEnemy()
    {
        GameObject projGO = Instantiate<GameObject>(projectileEnemy);
        projGO.transform.position = transform.position;
        Rigidbody2D rigidB = projGO.GetComponent<Rigidbody2D>();
        rigidB.velocity = Vector2.down * projectileSpeed;
        Invoke("FireEnemy", timeProjectile);
    }
}
