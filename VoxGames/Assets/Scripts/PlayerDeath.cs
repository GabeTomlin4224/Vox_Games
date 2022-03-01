using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
   [SerializeField] Vector2 deathKick = new Vector2(25f, 25f);
  
  
   bool isAlive = true;
   CapsuleCollider2D myBodyCollider;
   Rigidbody2D myRigidBody;
   void Start ()
   {
       myBodyCollider = GetComponent<CapsuleCollider2D>();
   }
   
   
   void Update ()
   {
       if (!isAlive)
       {
           return;
       }

       Die();
   }


   private void Die()
   {
       if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
       {
           isAlive = false;
           GetComponent<Rigidbody2D>().velocity = deathKick;
       }
   }
}
