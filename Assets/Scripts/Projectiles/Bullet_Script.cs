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
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = (Player.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x, direction.y) * force;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer != LayerMask.GetMask("Enemy") || collision.gameObject.layer != LayerMask.GetMask("Enemy Projectile"))
        { Destroy(gameObject); }

        Debug.Log(collision.gameObject.layer);

        if (collision.gameObject == Player)
        {
            Player.GetComponent<PlayerHealth>().takeDamage(1);
        }

    }
}
