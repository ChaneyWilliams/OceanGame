using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject bulletPrefab;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        SoundEfffectManager.Play("ButtonClick");
        pauseMenuUI.SetActive(false);
        bulletPrefab.SetActive(true);
        GameIsPaused = false;
        Time.timeScale = 1f;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        bulletPrefab.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        SoundEfffectManager.Play("ButtonClick");
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public void Retry()
    {
        SoundEfffectManager.Play("ButtonClick");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
