using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        //Trigger the jump animation if we collide with a heavy knight
        if (otherObject.GetComponent<HeavyKnight>())
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");

        }
        //Else attack
        else if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
