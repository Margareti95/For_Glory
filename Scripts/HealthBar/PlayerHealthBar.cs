using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ВНИМАНИЕ! ЭТОТ СКРИПТ НУЖЕН ДЛЯ ОБЪЕКТА ТЕРРАРИИ! НЕОБХОДИМО ПЕРЕИМЕНОВАТЬ В СООТВЕТСТВУЮЩИЙ! (не playerHealthBar, а terrariaHealthBar)
public class PlayerHealthBar : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        // Каждый раз обновляем значение (есть попадание - обновляем)

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
       
        GameObject gO = coll.gameObject;
        if (gO.tag == "ProjectileEnemy")
        {
            TakeDamage(20); // Высчитываем дамаг из хелсбара
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
