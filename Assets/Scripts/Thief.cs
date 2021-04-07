using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] int attackingWorth = 50;
    [SerializeField] public int fleeingWorth = 100; //public so we can counteract the award if he flees offscreen
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if(otherObject.GetComponent<Alchemist>() && GetComponent<Animator>().GetBool("isFleeing") == false)
        {
            GetComponent<Animator>().SetBool("isFleeing", true);
            Destroy(otherCollider.gameObject);
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else if (otherObject.GetComponent<Defender>())
        {
            //if(!otherObject.GetComponent<Shooter>())
                GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
