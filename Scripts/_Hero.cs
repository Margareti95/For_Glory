using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _Hero : MonoBehaviour
{
    Rigidbody2D rigidB2D;

    static public _Hero S;

    [Header("���� � ��������")]
    public float speed = 20f;

    public GameObject projectilePrefab;
    public float projectileSpeed = 40;

    [Header("�������� ���������")] // ����������� �������� �������� ���������. ����������� ����� �������� � � ��������, ����������
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

    void Move() // ������������ ���������
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

    void DestroyEnemy() // ����������� ���� ������, ����������� � �����
    {
        GameObject[] enemyDestroy = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject gO in enemyDestroy)
            Destroy(gO);
    }

    private void OnTriggerEnter2D(Collider2D coll2D) // ��������� ������� �� ������. ����� ��������� ������
    {
        switch(coll2D.gameObject.tag)
        {
            /*
             ������ ��� ����� - ������
            */
             
            case "PowerUp_Health": // ��������� ��������
                hpHero += 1;
                Info.text = "Health: " + hpHero;
                Destroy(coll2D.gameObject);
                break;

            case "PowerUp_Shield": // ���
                //shield.SetActive(true);
                Destroy(coll2D.gameObject);
                break;

            case "PowerUp_Racket":
                DestroyEnemy();
                Destroy(coll2D.gameObject);
                break;

            default: // ��������� �� ������
                hpHero -= 1;
                Info.text = "Health: " + hpHero; // ��������� ��������
                if (hpHero == 0)
                {
                    Destroy(coll2D.gameObject);
                    Info.text = "���� ���������! ���������� ������ ����� 3 �������";
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