using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerAttack : MonoBehaviour
{
    public Animator Animator;
    public Transform attack_Point;
    public float attack_range = 0.6f;
    public LayerMask enemyLayers;
    public LayerMask enemy_projectileMask;
    public int attack_Damage = 1;
    public TextMeshProUGUI scoreGUI;
    public int score = 0;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Melee();
        }
        
    }

    void Melee()

    {
        //Attacking Animation
        Animator.SetTrigger("Melee");

        //Detect enemies in range of Attack

        Collider2D[] Hit_Enemies = Physics2D.OverlapCircleAll(attack_Point.position, attack_range, enemyLayers);

        Collider2D[] Hit_Projectiles = Physics2D.OverlapCircleAll(attack_Point.position, attack_range * 1.85f, enemy_projectileMask);

        

        //Do Damage here!

        foreach (Collider2D projectile in Hit_Projectiles)
        { Destroy(projectile.gameObject); }

            foreach (Collider2D enemy in Hit_Enemies)
        {


            StartCoroutine(Damage_VFX(enemy.GetComponent<SpriteRenderer>()));

            if (enemy.GetComponent<Enemy>().currentHealth == 1)
            {
                score += 1;
                scoreGUI.text = "Score: " + score;
            }

            enemy.GetComponent<Enemy>().takeDamage(attack_Damage);

           

        
        }
    }



    

   

    void OnDrawGizmosSelected()

       

    {
        if (attack_Point == null)
            return;

        Gizmos.DrawWireSphere(attack_Point.position, attack_range);    
    }

    public IEnumerator Damage_VFX(SpriteRenderer rend)
    {
        rend.color = Color.red;
        yield return new WaitForSeconds(0.08f);

        if (rend != null)
        { rend.color = Color.white; }
    }
}


