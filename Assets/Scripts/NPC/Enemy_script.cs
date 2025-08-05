using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Script : MonoBehaviour
{
 

    public GameObject Bullet;
    public Transform BulletPos;
    private GameObject Player;

    private float timer;
    private float max_time = 1;
    private bool isActive = false;
    private float checkRadius = 6;
    public float max_bullettime;
    public float min_bullettime;
    private LayerMask playerLayer;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerLayer = LayerMask.GetMask("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if ( isActive)

        {
            isActive = false;
            max_time = Random.Range(min_bullettime, max_bullettime);
        }

        if (timer >= max_time)
        {


            isActive = Physics2D.OverlapCircle(transform.position, checkRadius, playerLayer);
            timer = 0;

            if (isActive)
            { shoot(); }

        }
    }
    void shoot()
    {
        Instantiate(Bullet, BulletPos.position, Quaternion.identity);
    }
}