using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject playerPrefab;

    public List<Level> levels;
    Level currentLevel;

    private bool levelStarted = false;

    public int lootCounter;
    public int lootToWin;
    public string nextScene;

    public Image heart1;
    public Image heart2;
    public Image heart3;
    
    void Start()
    {
        //SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        
        InitGame();
    }

    void InitGame()
    {
        LoadLevel(SceneManager.GetActiveScene().name);

        SceneManager.activeSceneChanged += ActiveSceneChanged;
    }

    void ActiveSceneChanged(Scene arg0, Scene scene)
    {
        StartCoroutine(ShowPlayer(3));
    }


    void LoadLevel(string sceneName)
    {
        currentLevel = levels.First(l => l.scene.Equals(sceneName));
        lootCounter = currentLevel.lootCounter;
        lootToWin = currentLevel.lootToWin;
        levelStarted = true;
    }


    IEnumerator ShowPlayer(int seconds)
    {
        GameObject player = Instantiate(playerPrefab, currentLevel.spawnPoint, Quaternion.identity);

        var sprite = player.GetComponent<SpriteRenderer>();
        var color = sprite.color;

        color.a = 0;
        sprite.color = color;

        for (float f = 0; f <= 1; f += 0.05f)
        {
            color.a = f;
            sprite.color = color;
            yield return new WaitForSeconds(seconds / 20);
        }
    }


    void LoadAndInitNextLevel()
    {
        var nextIndex = levels.IndexOf(currentLevel) + 1;

        if (nextIndex >= levels.Count)
        {
            EndGame();
        }
        else
        {
            SceneManager.LoadScene(levels[nextIndex].scene);
            LoadLevel(levels[nextIndex].scene);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            EndGame();
        }

        if (levelStarted)
        {
            if (lootCounter >= lootToWin)
            {
                levelStarted = false;
                LoadAndInitNextLevel();
            }
        }

        if(heart1 == null || heart2 == null || heart3 == null)
        {
            return;
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

    void EndGame()
    {
        SceneManager.activeSceneChanged -= ActiveSceneChanged;
        Destroy(gameObject);
        SceneManager.LoadScene("Menu");
    }
}
