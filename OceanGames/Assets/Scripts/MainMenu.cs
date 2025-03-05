using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("Level1");
    }

    //Guess what this does
    public void QuitGame()
    {
        Application.Quit();
    }
}
