using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public float transtime = 1;
    public GameObject screen;
    public GameObject video;
    VideoPlayer videoPlayer;


    public void Awake()
    {
        videoPlayer = video.GetComponent<VideoPlayer>();
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    //Guess what this does
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        StartCoroutine(LoadLevel(4));
    }

    public void Skip()
    {
        videoPlayer.Pause();
        screen.SetActive(false);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transtime);
        SceneManager.LoadScene(levelIndex);
    }
}
