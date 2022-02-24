using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("��������� �������� �����������")]
    private float randY;
    Vector2 spawn; // ��������� ������� ��������� ����������
    public GameObject[] prefabEnemies; // ������ ��������� ���������

    public int count = 10; // ����� ����������
    private float t = 0; // ��� ��������
    public float timeSpawn; // ����� ������

      
    void Update()
    {
        TimeSpawn(); // ���������� ������ �������
    }

    private void SpawnEn() // ��������� ��������� ����������
    {
      int Idex = Random.Range(0, prefabEnemies.Length);
      randY = Random.Range(3.77f, 2.12f);
      spawn = new Vector2(transform.position.x, randY);
      Instantiate(prefabEnemies[Idex], spawn, Quaternion.identity);
    }

    private void TimeSpawn() // ������������ ���������� �������� ����������� ��������
    {
        t += Time.deltaTime;

        if (t >= timeSpawn)
        {
            if (count > 0)
            {
                SpawnEn();
                count = count - 1; // ����������� �� ������ ����������
                t = 0; // ����� ��������� ���������� ����������
            }

        }
    }

}
