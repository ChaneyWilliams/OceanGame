using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CutsceneOver : MonoBehaviour
{
    public Animator transition;
    public float transtime = 30;

    void Update()
    {
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(transtime);
        transition.SetTrigger("Start");
    }
}
