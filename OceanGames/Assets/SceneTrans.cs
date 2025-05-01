using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTrans : MonoBehaviour
{
    public Animator transition;
    public float transtime = 1;
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transtime);
        SceneManager.LoadScene(levelIndex);
    }
}
