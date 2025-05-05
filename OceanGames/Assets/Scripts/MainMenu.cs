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
        SoundEfffectManager.Play("ButtonClick");
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    //Guess what this does
    public void QuitGame()
    {
        SoundEfffectManager.Play("ButtonClick");
        Application.Quit();
    }

    public void Credits()
    {
        transition.SetTrigger("Start");
        StartCoroutine(LoadLevel(4));
        SoundEfffectManager.Play("ButtonClick");
    }

    public void Skip()
    {
        SoundEfffectManager.Play("ButtonClick");
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
