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

/*����� WeaponDefinition ��������� ����������� ��������
����������� ���� ������ � ����������. ��� ����� ����� Main
����� ������� ������ ��������� ���� WeaponDefinition.*/

public class WeaponDefinition
{
    public WeaponType type = WeaponType.none;
    public string letter; // ����� �� ������� ������
    public Color color = Color.white; // ���� ������� ������
    public GameObject projectilePrefab; // ������ ��������

    public float damageOnHit = 0; // ������������� ��� �������-������
    public float velocity = 20; // �������� ������ ��������
}

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    
}
