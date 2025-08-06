using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public int Health = 15;
    public int currentHealth;
    private GameObject Player;
    public TextMeshProUGUI Health_Text;

    void Start()
    {
        currentHealth = Health;
        Player = GameObject.FindGameObjectWithTag("Player");

        Health_Text.text = "Health: " + currentHealth;

    }

    public void takeDamage(int damage)
    {

        currentHealth -= damage;

        //Optional Animation

        if (currentHealth > 50)
        { currentHealth = 50; }

        Health_Text.text = "Health: " + currentHealth;

        StartCoroutine(Damage_VFX(Player.GetComponent<SpriteRenderer>(),damage));


        if (currentHealth <= 0)
        { Die(); }

    }


    void Die()
    {
        //Optional Death Animation


        Debug.Log("Player Died");
        SceneManager.LoadScene("Game over screen");

        //Disable Enemy

    }

    public IEnumerator Damage_VFX(SpriteRenderer rend, int damage)
    {
        if (damage > 0)
        { rend.color = Color.red; }
        else { rend.color = Color.green; }
        yield return new WaitForSeconds(0.08f);
        rend.color = Color.white;

    }

}
