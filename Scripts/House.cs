using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public int count;
    public Sprite firstSprite, secondSprite;
    private SpriteRenderer sRenderer;

    private void OnTriggerEnter2D(Collider2D coll2D)
    {
        GameObject gO = coll2D.gameObject;
        sRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        if (gO.tag == "ProjectileEnemy")
        {
            switch (count)
            {
                case 3:
                    sRenderer.sprite = firstSprite;
                    count -= 1;
                    break;
                case 2:
                    sRenderer.sprite = secondSprite;
                    count -= 1;
                    break;
                default:
                    Destroy(gO);
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
