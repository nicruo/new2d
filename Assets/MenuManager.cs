using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string startScene;

    public void StartGameAction()
    {
        SceneManager.LoadScene(startScene);
    }

    public void EndGameAction()
    {
        Application.Quit();
    }

}
