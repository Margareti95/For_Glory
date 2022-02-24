using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public float cooldown; // Время действия щита, которые мы сами задаем

    [HideInInspector]
    public bool isCooldown; // Щит включен/выключен

    private Image shieldImage; // Спрайт с изображением щита
    private _Hero hero;

    // Start is called before the first frame update
    void Start()
    {
        shieldImage = GetComponent<Image>();
        hero = GameObject.FindGameObjectWithTag("_Hero").GetComponent<_Hero>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isCooldown)
        {
            shieldImage.fillAmount -= 1 / cooldown * Time.deltaTime; // Уменьшение время действия щита
           
            if(shieldImage.fillAmount <= 0)
            {
                shieldImage.fillAmount = 1;
                isCooldown = false;
                hero.shield.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }

    public void ResetTimer()
    {
        shieldImage.fillAmount = 1;
    }
}
