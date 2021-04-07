using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject lossLabel;
    [SerializeField] float winDelay = 3f;
    [SerializeField] AudioClip winSound;
    [SerializeField] [Range(0, 1)] float winSoundVolume = 0.5f;
    [SerializeField] AudioClip loseSound;
    [SerializeField] [Range(0, 1)] float loseSoundVolume = 0.5f;

    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        lossLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if(numberOfAttackers <= 0 && levelTimerFinished == true)
        {
            if(!lossLabel.activeSelf)
                HandleWinCondition();
        }
    }

    public void HandleWinCondition()
    {
        winLabel.SetActive(true);
        AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position, winSoundVolume);
        FindObjectOfType<CursorController>().DefaultCursor();
        Time.timeScale = 0;
    }

    public void HandleLossCondition()
    {
        lossLabel.SetActive(true);
        AudioSource.PlayClipAtPoint(loseSound, Camera.main.transform.position, loseSoundVolume);
        FindObjectOfType<CursorController>().DefaultCursor();
        Time.timeScale = 0; //Stop the game
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
