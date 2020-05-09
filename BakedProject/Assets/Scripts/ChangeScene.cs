using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private string finalSceneName;


    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(finalSceneName);
    }
}
