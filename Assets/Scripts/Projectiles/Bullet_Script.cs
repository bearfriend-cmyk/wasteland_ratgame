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

        Debug.Log(direction);
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
}
