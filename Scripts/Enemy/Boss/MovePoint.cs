using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    public float speed;

    private float pause; // Время паузы
    public float pauseOut;

    public Transform[] movePoints;
    private int randPoints;

    void Start()
    {
        pause = pauseOut;
        randPoints = Random.Range(0, movePoints.Length);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePoints[randPoints].position, speed*Time.deltaTime);
        
        if(Vector2.Distance(transform.position, movePoints[randPoints].position) < 0.2f)
        {
            if(pause <= 0)
            {
                // Переход на следующую случайную точку

                randPoints = Random.Range(0, movePoints.Length);
                pause = pauseOut; // сброс времени
            }

            else
            {
                pause -= Time.deltaTime;
            }
        }
    }

}
