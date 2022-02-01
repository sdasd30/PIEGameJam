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
    //public int burst = 1;
    private float reload_timer;
    private float prev_time;

    public bool automaticFire;

    // Start is called before the first frame update
    void Start()
    {
        //player = transform;
    }

    public void ModifyWeapon(float dam, float spd, float atk, float sprd, int count, int burst, bool automatic)
    {
        bulletDamage *= dam;
        BulletSpeed *= spd;
        ReloadSpeed *= atk;
        bulletSpread *= sprd;
        bulletCount += count;

        if (automatic)
        {
            automaticFire = true;
        }
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
                    Vector3 mousePos = Input.mousePosition;

                    Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
                    mousePos.x = mousePos.x - objectPos.x;
                    mousePos.y = mousePos.y - objectPos.y;
                    float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
                    GameObject b = Instantiate(BulletPrefab,
                        transform.position + transform.right * BulletSpawnDistance,
                        Quaternion.Euler(new Vector3(0, 0, angle)));
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
