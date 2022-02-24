using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_3 : MonoBehaviour
{
    public float speed = 10f;

    [Header("Список бонусов")]
    public GameObject[] prefabBonuses = new GameObject[0];
    private int Index;

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
    }

    void Update()
    {

        Move();

        if (bndCheck != null && bndCheck.offRight)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        // Движение по оси икс слева-направо
        Vector2 tempPos = pos;
        tempPos.x += speed * Time.deltaTime;
        pos = tempPos;

    }

    private void OnTriggerEnter2D(Collider2D coll2D)
    {
        GameObject gO = coll2D.gameObject;

        Index = Random.Range(0, prefabBonuses.Length);

        if (gO.tag == "ProjectileHero") // Противник сталкивается со снарядом игрока
        {
            Destroy(gO);
            Destroy(gameObject);
            Instantiate(prefabBonuses[Index], transform.position, Quaternion.identity); // Бонусы выпадают с противников

        }
    }
}
