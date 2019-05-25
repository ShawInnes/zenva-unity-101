using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private int requiredCoins;

    private Game game;

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<Game>();
        requiredCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    public void CheckForCompletion(int coinCount)
    {
        if (coinCount >= requiredCoins)
        {
             game.LoadNextLevel();
        }
        else
        {
            Debug.Log("you don't have enough coins");
        }
    }
}
