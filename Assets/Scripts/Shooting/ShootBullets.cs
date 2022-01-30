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
    public int bulletCount = 1;
    private float reload_timer;
    private float prev_time;

    // Start is called before the first frame update
    void Start()
    {
        //player = transform;
    }

    public void ChangeWeapon(float dam, float spd, float atk, float sprd, int count)
    {
        bulletDamage = dam;
        BulletSpeed = spd;
        ReloadSpeed = atk;
        bulletSpread = sprd;
        bulletCount = count;
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
                    b.transform.Rotate(new Vector3(0,0,Random.Range(-bulletSpread, bulletSpread)));
                    b.GetComponent<Rigidbody2D>().velocity = BulletSpeed * b.transform.right;//* toMouse;
                    
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
