using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("Случайное создание противников")]
    private float randY;
    Vector2 spawn; // Случайная позиция появления противника
    public GameObject[] prefabEnemies; // Массив вражеских самолетов

    public int count = 10; // Общее количество
    private float t = 0; // Для проверки
    public float timeSpawn; // Время спауна

      
    void Update()
    {
        TimeSpawn(); // Происходит каждую секунду
    }

    private void SpawnEn() // Рандомное появление противника
    {
      int Idex = Random.Range(0, prefabEnemies.Length);
      randY = Random.Range(3.77f, 2.12f);
      spawn = new Vector2(transform.position.x, randY);
      Instantiate(prefabEnemies[Idex], spawn, Quaternion.identity);
    }

    private void TimeSpawn() // Определенное количество случайно создаваемых объектов
    {
        t += Time.deltaTime;

        if (t >= timeSpawn)
        {
            if (count > 0)
            {
                SpawnEn();
                count = count - 1; // Высчитываем из общего количества
                t = 0; // Время появления следующего противника
            }

        }
    }

}
