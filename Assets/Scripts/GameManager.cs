using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ghost[] _ghosts;
    [SerializeField] private Pacman _pacman;
    [SerializeField] private Transform _pellets;
    [SerializeField] private int _numberOfLives = 3;

    public int score { get; private set; }
    public int lives { get; private set; }

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (lives <= 0 && Input.anyKeyDown)
        {
            NewGame();
        }
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(_numberOfLives);
        NewRound();
    }

    private void NewRound()
    {
        foreach (Transform pellet in _pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {
        for (int i = 0; i < _ghosts.Length; i++)
        {
            _ghosts[i].gameObject.SetActive(true);
        }

        _pacman.gameObject.SetActive(true);
    }

    private void GameOver()
    {
        for (int i = 0; i < _ghosts.Length; i++)
        {
            _ghosts[i].gameObject.SetActive(false);
        }

        _pacman.gameObject.SetActive(false);
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    public void GhostEaten(Ghost ghost)
    {
        SetScore(score + ghost.Points);
    }

    public void PacmanEaten()
    {
        _pacman.gameObject.SetActive(false);

        SetLives(lives - 1);

        if (lives > 0)
        {
            Invoke(nameof(ResetState), 2f);
        }
        else
        {
            GameOver();
        }

    }
}
