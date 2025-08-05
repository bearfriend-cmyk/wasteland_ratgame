using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class pipespawnscript : MonoBehaviour
{

    public GameObject pipe;
    public float spawnrate = 2;
    public float timer = 0;
    public float heightoffset;

    // Start is called before the first frame update
    void Start()
    {

        Spawnpipe();

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnrate)
        {
            timer = timer + Time.deltaTime;
        }

        else
        {
            Spawnpipe();
            timer = 0;
        }
    }
    void Spawnpipe()
    {
        float lowestPoint = transform.position.y - heightoffset;
        float highestPoint = transform.position.y + heightoffset;

        Instantiate(pipe, new Vector3( transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
