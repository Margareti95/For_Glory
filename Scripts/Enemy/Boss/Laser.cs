using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [Header("Характеристики лазера")]
    
    public GameObject laserBoss;
    public float timeLaser = 8f;
    public float projectileSpeed = 2f;

    void Awake()
    {
        Invoke("FireEnemy", timeLaser);
    }

    
    public virtual void FireEnemy()
    {
        GameObject projGO = Instantiate<GameObject>(laserBoss);
        Invoke("FireEnemy", timeLaser);
    }
}
