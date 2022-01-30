using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float damage;
    FactionType faction;

    public void Setup(float ndam, FactionType mFaction)
    {
        damage = ndam;
        faction = mFaction;
    }


    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered Collider");
        GameObject other = collision.gameObject;
        if (other.GetComponent<Attackable>() != null)
        {
            Attackable otherAttackable = collision.gameObject.GetComponent<Attackable>();

            if (otherAttackable.mFaction != FactionType.IMMUNE)
            {
                if (otherAttackable.mFaction != faction)
                {
                    otherAttackable.TakeDamage(damage);
                    if(this.GameObject.tag == "enemy"){
                        ScoreTracker.AddToScore(1);
                    }
                    Destroy(this.gameObject);
                }
            }
            else
            {   if(this.GameObject.tag == "enemy"){
                ScoreTracker.AddToScore(1);
            }
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (other.tag == "Wall" && this.GetComponent<Bullet>() != null)
            {   if(this.GameObject.tag == "enemy"){
                ScoreTracker.AddToScore(1);
            }
                Destroy(this.gameObject);
            }
        }
    }
}
