using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    internal void SetScore(int amount) { _score += amount; }
    internal void RemovePrey(Prey preyToRemove) { _prey.Remove(preyToRemove); }
    
    [SerializeField] private float roundDuration;
    
    private List<Prey> _prey;
    private List<Hunter> _hunters;
    private int _score;
    private float _timer;

    private void Awake()
    {
        #region Singleton

        if (Instance is null)
            Instance = this;
        else if(Instance != null && Instance != this)
            Destroy(gameObject);
        
        DontDestroyOnLoad(this);
        #endregion
        
        _prey = new List<Prey>();
        _hunters = new List<Hunter>();
    }

    private void Update()
    {
        roundDuration -= Time.deltaTime;
        
        if(Convert.ToInt32(roundDuration) == 0)
            EndRound();
    }
    
    private void EndRound()
    {
        Debug.Log("END");
    }
}
