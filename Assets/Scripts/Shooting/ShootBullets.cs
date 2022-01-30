using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullets : MonoBehaviour
{
    private GameObject player;
    public KeyCode FireKey;
    public GameObject BulletPrefab;
    public float bulletDamage;
    public float BulletSpeed;
    public float BulletSpawnDistance;
    public float ReloadSpeed;
    public float bulletSpread;
    public float bulletCount = 1;
    private float reload_timer;
    private float prev_time;

    // Start is called before the first frame update
    void Start()
    {
        //player = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (reload_timer >= ReloadSpeed)
        {
            if (Input.GetMouseButton(0))
            {
                //Vector3 toMouse = (Input.mousePosition - transform.position).normalized;
                for (int i = 0; i < bulletCount; i++)
                {
                    GameObject b = Instantiate(BulletPrefab,
                        transform.position + transform.right * BulletSpawnDistance,
                        transform.rotation);
                    b.GetComponent<Bullet>().Setup(bulletDamage, GetComponent<Attackable>().mFaction);
                    b.GetComponent<Rigidbody2D>().velocity = BulletSpeed * transform.right;//* toMouse;
                    b.GetComponent<Rigidbody2D>().MoveRotation(Random.Range(-bulletSpread, bulletSpread));
                }
                reload_timer = 0;
            }
        }
        else
        {
            reload_timer += Time.deltaTime;
        }
    }

}
