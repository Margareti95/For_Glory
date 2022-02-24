using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBoss : MonoBehaviour
{

    [Header("�������� �����")]
    public float hp;

    [Header("������ �������")]
    public GameObject[] prefabBonuses = new GameObject[0];
    private int Index;

    private void OnTriggerEnter2D(Collider2D coll2D)
    {
        GameObject gO = new GameObject();
        gO = coll2D.gameObject;

        Index = Random.Range(0, prefabBonuses.Length);

        if (gO.tag == "ProjectileHero")
        {
            hp -= 1;
            if(hp == 0)
            {
                Destroy(gO);
                Destroy(gameObject);
                Instantiate(prefabBonuses[Index], transform.position, Quaternion.identity); // ������ �������� � �����������
            }
        }
    }
}
