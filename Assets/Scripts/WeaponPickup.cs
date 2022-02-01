using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletDamage;
    public float BulletSpeed;
    public float ReloadSpeed;
    public float bulletSpread;
    public int bulletCount = 1;

    public float decayTime = 30;
    void Update()
    {
        decayTime -= Time.deltaTime;
        if (decayTime <= 0f) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hit = collision.gameObject;

        if (hit.GetComponent<PlayerController>() != null)
        {
            //hit.GetComponent<ShootBullets>().ModifyWeapon(bulletDamage, BulletSpeed, ReloadSpeed, bulletSpread, bulletCount);
            Destroy(this.gameObject);

        }    
    }
}
