using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Span : MonoBehaviour
{
    public GameObject enemyPreferb;
    private float spanrange = 9.0f;
    public int enemycount;
    public int waveNumber = 1;
    public GameObject powerupPrefebs;

    // Start is called before the first frame update
    void Start()
    {
        SpanEnemyWave(waveNumber);
        Instantiate(powerupPrefebs, GenerateSpanPosition(),
            powerupPrefebs.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemycount = FindObjectsOfType<Enemy>().Length;
        if (enemycount == 0)
        { Instantiate(powerupPrefebs, GenerateSpanPosition(),
    powerupPrefebs.transform.rotation);
        
            waveNumber++;
            SpanEnemyWave(waveNumber);
        }
    }
    void SpanEnemyWave(int enemytospan)
    { 
        for (int i = 0; i < enemytospan; i++) 
        {
            Instantiate(enemyPreferb, GenerateSpanPosition(), enemyPreferb.transform.rotation);
        }
    }

    private Vector3 GenerateSpanPosition()
    {
        float spanposX = Random.Range(-spanrange, spanrange);
        float spanposZ = Random.Range(-spanrange, spanrange);

        Vector3 randomPos = new Vector3(spanposX, 0, spanposZ);
        return randomPos;
    }
}
