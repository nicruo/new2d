using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int lootCounter = 0;
    public int lootToWin = 3;
    public string nextScene;

    public Image heart1;
    public Image heart2;
    public Image heart3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        if(lootCounter >= lootToWin)
        {
            SceneManager.LoadScene(nextScene);
        }

        if(PlayerControl.life > 2)
        {
            heart1.enabled = true;
            heart2.enabled = true;
            heart3.enabled = true;
        }
        else if(PlayerControl.life > 1)
        {
            heart1.enabled = true;
            heart2.enabled = true;
            heart3.enabled = false;
        }
        else if(PlayerControl.life > 0)
        {
            heart1.enabled = true;
            heart2.enabled = false;
            heart3.enabled = false;
        }
        else if (PlayerControl.life > -1)
        {
            heart1.enabled = false;
            heart2.enabled = false;
            heart3.enabled = false;
        }

    }
}
