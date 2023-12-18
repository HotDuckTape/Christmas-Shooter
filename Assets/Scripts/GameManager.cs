using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPosPlayer1, spawnPosPlayer2;
    [SerializeField] private Canvas gameOverScreen;
    private GameObject player1, player2;
    private bool gameStarted;

    private void Start()
    {
        gameOverScreen.enabled = false;
    }

    private void Update()
    {
        if (player1 != null && player2 != null)
        {
            gameStarted = true;
        }
        else
        {
            if (gameStarted)
                return; 

            OnPlayerJoin();
        }

        if (gameStarted)
        {
            player1.transform.position = spawnPosPlayer1.position;
            player2.transform.position = spawnPosPlayer2.position;

            CheckForDeath();
        }
    }

    private void OnPlayerJoin()
    {
        GameObject[] playerOne = GameObject.FindGameObjectsWithTag("PlayerOne");
        GameObject[] playerTwo = GameObject.FindGameObjectsWithTag("PlayerTwo");

        player1 = playerOne[0];
        player2 = playerTwo[0];
    }

    private void CheckForDeath()
    {
        PlayerHealth playerHealth1 = player1.GetComponent<PlayerHealth>();
        PlayerHealth playerHealth2 = player2.GetComponent<PlayerHealth>();

        if (playerHealth1.isDead && playerHealth2.isDead)
        {
            gameOverScreen.enabled = true;
        }
    }
}
