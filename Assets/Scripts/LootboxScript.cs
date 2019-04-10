using UnityEngine;

public class LootboxScript : MonoBehaviour
{
    public int points = 1;
    GameObject gameManagerObject;
    GameManager gameManager;

    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    void OnDestroy()
    {
        gameManager.lootCounter += points;
    }
}