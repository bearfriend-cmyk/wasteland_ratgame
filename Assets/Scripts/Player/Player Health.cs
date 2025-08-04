using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    int currentHealth;

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

        Debug.Log("Enemy Died");
        Destroy(gameObject);

        //Disable Enemy

    }
}
