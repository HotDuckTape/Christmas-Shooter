using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosPlayer1, _spawnPosPlayer2;
    [SerializeField] private Canvas _gameOverScreen;
    private GameObject _player1, _player2;
    private bool _gameStarted;

    private void Start()
    {
        _gameOverScreen.enabled = false;     
    }

    private void Update()
    {
        if (_player1 != null && _player2 != null)
        {
            _gameStarted = true;
        }
        else
        {
            if (_gameStarted)
                return; 

            OnPlayerJoin();
        }

        if (_gameStarted)
        {
            _player1.transform.position = _spawnPosPlayer1.position;
            _player2.transform.position = _spawnPosPlayer2.position;

            CheckForDeath();
        }
    }

    private void OnPlayerJoin()
    {
        GameObject[] playerOne = GameObject.FindGameObjectsWithTag("PlayerOne");
        GameObject[] playerTwo = GameObject.FindGameObjectsWithTag("PlayerTwo");

        _player1 = playerOne[0];
        _player2 = playerTwo[0];

        _player1.tag = "PlayerOne";
        _player2.tag = "PlayerTwo";

    }

    private void CheckForDeath()
    {
        PlayerHealth playerHealth1 = _player1.GetComponent<PlayerHealth>();
        PlayerHealth playerHealth2 = _player2.GetComponent<PlayerHealth>();

        if (playerHealth1.isDead && playerHealth2.isDead)
        {
            _gameOverScreen.enabled = true;
        }
    }
}
