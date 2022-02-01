using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    DependentSpawner[] spawners;
    public List<GameObject> pickups;
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
        if (creditPool.buyUpgrade(30))
        {
            Vector3 shake = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
            nextSpawner.spawn(nextEnemy,shake);
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
            if (Vector3.Distance(spawner.transform.position, player.transform.position) >= 10f && CountEnemies() <= 10)
            {
                return spawner;
            }
        }
        Debug.LogError("Could not find viable spawner");
        return null;
    }

    private int CountEnemies()
    {
        return FindObjectsOfType<UniversalPickup>().Length;
    }

    private GameObject decideEnemy()
    {
        GameObject considering;
        considering = pickups[Random.Range(0, pickups.Count)];
        return considering;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 1, 0, .8f);
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}