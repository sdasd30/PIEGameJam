using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class UniversalPickup : MonoBehaviour
{
    //All float values are in percent
    public float damageUp = 1;
    public float speedUp = 1;
    public float spreadUp = 1;
    public float reloadUp = 1;
    public bool automatic = false;
    public int bulletCount = 0;
    public int burstCount = 0;

    //Except this one
    public float lightRadiusUp;

    public float decayTime = 30;

    private void Update()
    {
        decayTime -= Time.deltaTime;
        if (decayTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hit = collision.gameObject;

        if (hit.GetComponent<PlayerController>() != null)
        {
            hit.GetComponent<ShootBullets>().ModifyWeapon(damageUp, speedUp, reloadUp, spreadUp, bulletCount, burstCount, automatic);
            hit.GetComponentInChildren<Light2D>().pointLightInnerAngle += lightRadiusUp;
            hit.GetComponentInChildren<Light2D>().pointLightOuterAngle += lightRadiusUp;
            Destroy(this.gameObject);

        }
    }

}
