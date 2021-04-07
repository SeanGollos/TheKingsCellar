using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float damage = 50f;
    [SerializeField] float projectileSpeed = 2f;

    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";
    private void Start()
    {
        CreateProjectileParent();
        this.transform.parent = projectileParent.transform;
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
        var defender = otherCollider.GetComponent<Defender>();

        //If this projectile is an axe, damage defenders
        if(gameObject.name == "Axe(Clone)")
        {
            if (defender && health)
            {
                health.DealDamage(damage);
                Destroy(gameObject);
            }
        }

        else if(attacker && health)
        {
            
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
