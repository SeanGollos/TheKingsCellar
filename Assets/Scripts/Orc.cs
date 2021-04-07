using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour
{
    [SerializeField] GameObject projectile, arm;
   
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
    public void Fire()
    {
        Instantiate(projectile, arm.transform.position, transform.rotation);
        //newProjectile.transform.parent = transform;
    }
}
