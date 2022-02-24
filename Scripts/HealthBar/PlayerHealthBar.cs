using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��������! ���� ������ ����� ��� ������� ��������! ���������� ������������� � ���������������! (�� playerHealthBar, � terrariaHealthBar)
public class PlayerHealthBar : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        // ������ ��� ��������� �������� (���� ��������� - ���������)

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
       
        GameObject gO = coll.gameObject;
        if (gO.tag == "ProjectileEnemy")
        {
            TakeDamage(20); // ����������� ����� �� ��������
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
