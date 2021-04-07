using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject tutorialLabel;

    //Freeze time while tutorial is up
    void Start()
    {
        PauseTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PauseTime()
    {
        Debug.Log("Time should be paused");
        Time.timeScale = 0;
    }

    public void StartLevel()
    {
        Time.timeScale = 1;
        tutorialLabel.SetActive (false);    
    }
}
