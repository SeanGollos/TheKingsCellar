using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;

    [SerializeField] float minSpawnDelay = 1.0f;
    [SerializeField] float maxSpawnDelay = 5.0f;
    [SerializeField] Attacker[] attackerPrefabs;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        Attacker chosenAttacker;
        chosenAttacker = attackerPrefabs[Random.Range(0, attackerPrefabs.Length)];
        Spawn(chosenAttacker);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, transform.position, transform.rotation) as Attacker;

        newAttacker.transform.parent = transform;
    }
}
