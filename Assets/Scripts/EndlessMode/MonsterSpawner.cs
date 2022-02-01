using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    DependentSpawner[] spawners;
    public List<GameObject> enemies;
    public GameObject nextEnemy;
    private DependentSpawner nextSpawner;
    CreditPool creditPool;


    void Start()
    {
        spawners = FindObjectsOfType<DependentSpawner>();
        creditPool = GetComponent<CreditPool>();
        nextSpawner = searchSpawner();
        nextEnemy = decideEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (creditPool.spendCredit(nextEnemy.GetComponent<Attackable>().scoreValue) && CountEnemies() <= 100)
        {
            nextSpawner.spawn(nextEnemy, new Vector3(0,0,0));
            nextSpawner = searchSpawner();
            nextEnemy = decideEnemy();
        }
    }

    private DependentSpawner searchSpawner()
    {
        for (int i = 0; i < 999; i++)
        {
            DependentSpawner spawner = spawners[Random.Range(0, spawners.Length)];
            GameObject player = FindObjectOfType<PlayerController>().gameObject;
            if (Vector3.Distance(spawner.transform.position, player.transform.position) >= 10f)
            {
                return spawner;
            }
        }
        Debug.LogError("Could not find viable spawner");
        return null;
    }

    private int CountEnemies()
    {
        return FindObjectsOfType<EnemyMove>().Length;
    }

    private GameObject decideEnemy()
    {
        GameObject considering;
        considering = enemies[Random.Range(0, enemies.Count)];
        //Debug.Log("initial enemy is " + considering);
        //Debug.Log(creditPool.incrementby * 3);
        while (considering.GetComponent<Attackable>().scoreValue > (creditPool.incrementby * 3))
        {
            //Debug.Log("searching for a new enemy...");
            considering = enemies[Random.Range(0, enemies.Count)];
        }
        //private GameObject considering;
        //while ()
        //if !(enemies[Random.Range(0, enemies.Count)])
        //Debug.Log("seems reasonable, returning " + considering);
        return considering;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 1, 0, .8f);
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}