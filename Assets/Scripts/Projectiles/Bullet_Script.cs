using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;
    public float force;
    public float timer;
    public LayerMask Bullet_Layer;
    public LayerMask Enemy_Layer;

    // Start is called before the first frame update
    void Start()
    {
        Bullet_Layer = LayerMask.GetMask("Enemy Projectile");
        Enemy_Layer = LayerMask.GetMask("Enemy");

        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = (Player.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x, direction.y) * force;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject);

        if (collision.gameObject == Player)
        {
            Player.GetComponent<PlayerHealth>().takeDamage(1);          
        }
    
    }

  

}
