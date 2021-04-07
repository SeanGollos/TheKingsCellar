using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int waitOnSplashTime = 3;
    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }

        //Re-enable cursor on last screen
        if(currentSceneIndex >= 27)
        {
            Cursor.visible = true;
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(waitOnSplashTime);
        LoadNextScene();
    }
    public void RestartLevel()
    {
        Time.timeScale = 1;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadOptions()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Options Screen");
    }

    public void LoadNextScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadYouLose()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
