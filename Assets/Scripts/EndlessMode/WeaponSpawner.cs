using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    DependentSpawner[] spawners;
    public List<GameObject> weapons;
    private DependentSpawner nextSpawner;
    CreditPool creditPool;

    public float timer = 15f;
    float maxTimer;


    void Start()
    {
        spawners = FindObjectsOfType<DependentSpawner>();
        nextSpawner = searchSpawner();
        maxTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer = maxTimer;
            nextSpawner = searchSpawner();
            nextSpawner.spawn(weapons[Random.Range(0, weapons.Count)]);
        }
    }

    private DependentSpawner searchSpawner()
    {
        for (int i = 0; i < 999; i++)
        {
            DependentSpawner spawner = spawners[Random.Range(0, spawners.Length)];
            GameObject player = FindObjectOfType<PlayerController>().gameObject;
            if (Vector3.Distance(spawner.transform.position, player.transform.position) >= 5f)
            {
                return spawners[Random.Range(0, spawners.Length)];
            }
        }
        Debug.LogError("Could not find viable spawner");
        return null;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 1, 0, .8f);
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}