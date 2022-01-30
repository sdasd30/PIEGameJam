using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FactionType { IMMUNE, ALLIES, ENEMIES, NEUTRAL };

public class Attackable : MonoBehaviour
{
    public float contactHurt;
    public float maxHealth = 1;
    public float health = 1;
    public float invulnTime = 0;
    float curInvuln = 0;
    private bool alive = true;
    public FactionType mFaction = FactionType.ENEMIES;

    // Use this for initialization
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth) health = maxHealth;
        checkDead();
        curInvuln -= Time.deltaTime;
    }

    public void checkDead()
    {
        if (health <= 0 && alive)
        {
            alive = false;
        }
        if (!alive)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        if (curInvuln <= 0f)
        {
            health -= damage;
            health = Mathf.Min(maxHealth, health);
            curInvuln = invulnTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.GetComponent<Attackable>() != null)
        {
            Attackable otherAttackable = collision.gameObject.GetComponent<Attackable>();

            if (otherAttackable.mFaction != FactionType.IMMUNE)
            {
                if (otherAttackable.mFaction != mFaction)
                {
                    otherAttackable.TakeDamage(contactHurt);
                    TakeDamage(otherAttackable.contactHurt);
                }
            }
        }
        else
        {
            if (other.tag == "Wall" && this.GetComponent<Bullet>() != null)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
