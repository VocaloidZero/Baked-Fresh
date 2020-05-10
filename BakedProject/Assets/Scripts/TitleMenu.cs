using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleMenu : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
       
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
