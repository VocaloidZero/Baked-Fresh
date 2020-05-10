using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public Canvas Loader;

    private void Awake()
    {
        Loader.enabled = false;
        transition.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Loader.enabled = true;
            
            LoadNextLevel();
         
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.enabled = true;
        transition.SetBool("StartBool", false);

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
        
    }

}
