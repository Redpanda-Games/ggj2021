using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private float roundDuration;
    [SerializeField] private int scoreToWin;
    
    [Header("InputObjects")]
    [SerializeField] private TMP_Text timer;
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text result;
    [SerializeField] private GameObject endScreen;
    
    private int _score;
    private float _timer;
    private bool _hasPlayer;

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        _hasPlayer = true;
    }
    
    private void Awake()
    {
        #region Singleton

        if (Instance is null)
            Instance = this;
        else if(Instance != null && Instance != this)
            Destroy(gameObject);
        
        DontDestroyOnLoad(this);
        #endregion

        timer.text = roundDuration.ToString("00");

        GetComponent<PlayerInputManager>().onPlayerJoined += OnPlayerJoined;
    }
    
    private void Update()
    {
        if (!_hasPlayer) return;
        
        roundDuration -= Time.deltaTime;

        timer.text = Convert.ToInt32(roundDuration).ToString("00");
        
        if(_score >= scoreToWin)
            EndRound(true);
        else if(Convert.ToInt32(roundDuration) == 0)
            EndRound(false);
    }

    internal void SetScore(int amount)
    {
        _score += amount;
        score.text = _score.ToString("000");
    }
    
    private void EndRound(bool gameResult)
    {
        endScreen.SetActive(true);
        Time.timeScale = 0;

        switch (gameResult)
        {
            case true:
                result.text = "Mice win!";
                break;
            case false:
                result.text = "Mice lose.";
                break;
        }
    }
}
