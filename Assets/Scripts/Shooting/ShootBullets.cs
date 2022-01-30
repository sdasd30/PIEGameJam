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
    public float ReloadSpeed;
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
            if (Input.GetKey(FireKey))
            {
                Vector3 toMouse = (Input.mousePosition - transform.position).normalized;
                GameObject b = Instantiate(BulletPrefab,
                    transform.position + transform.right * BulletSpawnDistance,
                    transform.rotation);
                b.GetComponent<Rigidbody2D>().velocity = BulletSpeed * transform.right;//* toMouse;
                reload_timer = 0;
            }
        }
        else
        {
            reload_timer += Time.time - prev_time;
        }

        prev_time = Time.time;
    }

}
