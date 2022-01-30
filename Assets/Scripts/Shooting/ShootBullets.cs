using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullets : MonoBehaviour
{
    private GameObject player;
    public KeyCode FireKey;
    public GameObject BulletPrefab;
    public float BulletSpeed;
    public float BulletSpawnDistance;

    // Start is called before the first frame update
    void Start()
    {
        //player = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(FireKey))
        {
            Vector3 toMouse = (Input.mousePosition - transform.position).normalized;
            GameObject b = Instantiate(BulletPrefab,
               transform.position + toMouse * BulletSpawnDistance,
                Quaternion.FromToRotation(transform.right, toMouse));
            b.GetComponent<Rigidbody2D>().velocity = BulletSpeed * toMouse;
        }
    }
}
