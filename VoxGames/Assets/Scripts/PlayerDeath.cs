using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    
    [SerializeField] Vector2 deathKick = new Vector2(40f, 40f);
    [SerializeField] int playerLives = 3;
    bool isAlive = true;

    Rigidbody2D myRigidBody;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeet;
    
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(!isAlive)
        {
            return;
        }
        Die();
    }


    private void Die()
    {
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards", "Timer")))
        {
            isAlive = false;
            GetComponent<Rigidbody2D>().velocity = deathKick;
            FindObjectOfType<PlayerDeath>().ProcessDeath();
        }
    }


    private void Restart()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }


    private void TakeLife()
    {
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }


    private void ProcessDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            Restart();
        }
    }
}
