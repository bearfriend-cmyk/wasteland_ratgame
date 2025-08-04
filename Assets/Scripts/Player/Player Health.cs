using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    private GameObject Player;
    public TextMeshProUGUI Health_Text;

    void Start()
    {
        currentHealth = maxHealth;
        Player = GameObject.FindGameObjectWithTag("Player");

        Health_Text.text = "Health: " + currentHealth;

    }

    public void takeDamage(int damage)
    {

        currentHealth -= damage;

        //Optional Animation

        Health_Text.text = "Health: " + currentHealth;

        StartCoroutine(Damage_VFX(Player.GetComponent<SpriteRenderer>()));


        if (currentHealth <= 0)
        { Die(); }

    }


    void Die()
    {
        //Optional Death Animation


        Debug.Log("Player Died");
        SceneManager.LoadScene("Start screen");

        //Disable Enemy

    }

    public IEnumerator Damage_VFX(SpriteRenderer rend)
    {
        rend.color = Color.red;
        yield return new WaitForSeconds(0.08f);
        rend.color = Color.white;

    }

}
