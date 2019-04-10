using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string startScene;
    public GameObject GameManagerObject;

    public void StartGameAction()
    {
        SceneManager.LoadScene(startScene);
    }

    public void EndGameAction()
    {
        Application.Quit();
    }

}