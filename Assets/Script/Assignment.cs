using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour

{
    public int playerLevel = 5;
    public float playerHealth = 75.0f;
    string playerName = "Hero";

    void Start()
    {
        Debug.Log("Welcome to the Game!");

        CheckLevel();
        CheckHealth();
        BattleEnemies();
    }

    void CheckLevel()
    {
        if (playerLevel >= 10)
        {
            Debug.Log(playerName + " is a high-level player!");
        }
        else if (playerLevel >= 5)
        {
            Debug.Log(playerName + " is an intermediate-level player.");
        }
        else
        {
            Debug.Log(playerName + " is a beginner.");
        }
    }

    void CheckHealth()
    {
        if (playerHealth >= 100.0f)
        {
            Debug.Log(playerName + " is in perfect health!");
        }
        else if (playerHealth >= 50.0f)
        {
            Debug.Log(playerName + " is wounded but still fighting.");
        }
        else
        {
            Debug.Log(playerName + " is critically injured.");
        }
    }

    void BattleEnemies()
    {
        int numEnemies = Random.Range(1, 6); // Simulate 1 to 5 enemies

        Debug.Log("Battle begins! " + numEnemies + " enemies approach.");

        for (int i = 0; i < numEnemies; i++)
        {
            Debug.Log("Attacking enemy " + (i + 1) + "...");
            // Simulate the battle process here
        }

        Debug.Log("Battle ends. " + playerName + " emerges victorious!");
    }
}

