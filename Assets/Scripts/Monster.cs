using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Monster : MonoBehaviour
{

    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particleSystem;

    private bool _hasDied;

   void OnCollisionEnter2D(Collision2D collision)
   {
       if (ShouldDieFromCollision(collision))
       {
           Die();
       }

   }

   private void Die()
   {
       _hasDied = true;
       GetComponent<SpriteRenderer>().sprite = _deadSprite;
       _particleSystem.Play();
   }

   private bool ShouldDieFromCollision(Collision2D collision)
   {
       if (_hasDied)
            return false;

       Bird bird  = collision.gameObject.GetComponent<Bird>();

       if (bird != null)
       {
           return true;
       }

       if (collision.contacts[0].normal.y < -0.5)
       {
           return true;
       }

       return false;
   }
}
