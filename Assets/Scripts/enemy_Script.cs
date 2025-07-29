using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Script : MonoBehaviour
{
    public float Range;
    public float Damage;
    public Transform Player;
    bool Detected = false;

    Vector2 direction;

    public GameObject AlarmLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Player.position;
        direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayinfo = Physics2D.Raycast(transform.position,direction,Range);

        if (rayinfo)
        {
            if(rayinfo.collider.gameObject.tag == "player")
            {
                if(Detected == false)
                {
                    Detected = true;
                }
            }
            else
            {
                if(Detected == true)
                {
                    Detected = false;
                }
            }
        }
    }
}
