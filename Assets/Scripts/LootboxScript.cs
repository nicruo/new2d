using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootboxScript : MonoBehaviour
{
    public int points = 1;
    GameObject gameManagerObject;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManagerObject");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        gameManager.lootCounter += points;
    }
}
