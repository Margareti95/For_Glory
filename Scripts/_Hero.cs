using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _Hero : MonoBehaviour
{
    Rigidbody2D rigidB2D;

    static public _Hero S;

    [Header("Инфа о снарядах")]
    public float speed = 20f;

    public GameObject projectilePrefab;
    public float projectileSpeed = 40;

    [Header("Здоровье персонажа")] // Отображение счетчика здоровья персонажа. Аналогичный метод работает и с зданиями, счетчиками
    private float hpHero = 3;
    public Text Info;

    public GameObject shield;

    private void Awake()
    {
        if (S == null)
        {
            S = this;
        }
        else
        {
            Debug.LogError("Hero.Awake() - Attempted to assign second Hero.S!");
        }

        Info.text = "Health: " + hpHero;
    }

    void Move() // Передвижение персонажа
    {
        Vector2 pos = transform.position;
        float xAxis = Input.GetAxis("Horizontal");
        pos.x += xAxis * Time.deltaTime*speed;
        transform.position = pos;
    }

    void Fire()
    {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = transform.position;
        rigidB2D = projGO.GetComponent<Rigidbody2D>();
        rigidB2D.velocity = Vector2.up * projectileSpeed;
    }

    void DestroyEnemy() // Уничтожение всех врагов, находящихся в сцене
    {
        GameObject[] enemyDestroy = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject gO in enemyDestroy)
            Destroy(gO);
    }

    private void OnTriggerEnter2D(Collider2D coll2D) // Попадание снаряда по игроку. Игрок подбирает бонусы
    {
        switch(coll2D.gameObject.tag)
        {
            /*
             Первые три кейса - бонусы
            */
             
            case "PowerUp_Health": // Повышение здоровья
                hpHero += 1;
                Info.text = "Health: " + hpHero;
                Destroy(coll2D.gameObject);
                break;

            case "PowerUp_Shield": // Щит
                //shield.SetActive(true);
                Destroy(coll2D.gameObject);
                break;

            case "PowerUp_Racket":
                DestroyEnemy();
                Destroy(coll2D.gameObject);
                break;

            default: // Попадание по игроку
                hpHero -= 1;
                Info.text = "Health: " + hpHero; // Обновляем значение
                if (hpHero == 0)
                {
                    Destroy(coll2D.gameObject);
                    Info.text = "Игра закончена! Перезапуск уровня через 3 секунды";
                    Invoke("RestartScene", 3f);
                }
                break;
        }
    }

    void RestartScene()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }
}