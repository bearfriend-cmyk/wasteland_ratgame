using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{


    public int maxHealth = 3;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage)
    {

        currentHealth -= damage;

        //Optional Animation

        if (currentHealth <= 0)
        { Die(); }
    
    }


    void Die()
    {
        //Optional Death Animation

        Destroy(gameObject);

        //Disable Enemy

    }

   
}




