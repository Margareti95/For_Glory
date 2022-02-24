using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{ 
    none,
    blaster,
    shiled
}

[System.Serializable]

/*Класс WeaponDefinition позволяет настраивать свойства
конкретного вида оружия в инспекторе. Для этого класс Main
будет хранить массив элементов типа WeaponDefinition.*/

public class WeaponDefinition
{
    public WeaponType type = WeaponType.none;
    public string letter; // Буква на спрайте бонуса
    public Color color = Color.white; // Цвет спрайта бонуса
    public GameObject projectilePrefab; // Шаблон снарядов

    public float damageOnHit = 0; // Разрушаемость для снаряда-бонуса
    public float velocity = 20; // Скорость полета снарядов
}

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    
}
