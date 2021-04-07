using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    [SerializeField] Sprite openChest;

    //No parameter because we don't care what bumped into us
    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Only trigger if an attacker gets here
        if (otherCollider.gameObject.GetComponent<Attacker>())
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = openChest;
            FindObjectOfType<LevelController>().HandleLossCondition();
        }
    }
}
