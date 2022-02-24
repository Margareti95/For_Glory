using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class OnTriggered : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D coll2D)
        {
             GameObject gO = coll2D.gameObject;
             if (gO.tag == "ProjectileEnemy" || gO.tag == "ProjectileHero")
             {
               
                 Destroy(gO);
                 Destroy(gameObject);
             }
        }
    }
}
