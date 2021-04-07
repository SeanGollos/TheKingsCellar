using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] GameObject deathVFX;
    [SerializeField] AudioClip[] deathSounds;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.5f;
    [SerializeField] AudioClip[] hitSounds;
    [SerializeField] [Range(0, 1)] float hitSoundVolume = 0.5f;

    public void DealDamage(float damage)
    {
        health -= damage;
        AudioClip hitClip = hitSounds[Random.Range(0, hitSounds.Length)];
        AudioSource.PlayClipAtPoint(hitClip, Camera.main.transform.position, hitSoundVolume);
        if (health <= 0)
        {
            TriggerDeath();
            Destroy(gameObject);
        }
    }

    private void TriggerDeath()
    {
        if (!deathVFX) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        AudioClip deathClip = deathSounds[Random.Range(0, deathSounds.Length)];
        AudioSource.PlayClipAtPoint(deathClip, Camera.main.transform.position, deathSoundVolume);
        Destroy(deathVFXObject, 1f);
    }
}
