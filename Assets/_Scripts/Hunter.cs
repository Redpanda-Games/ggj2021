using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

[RequireComponent(typeof(NavMeshAgent))]
public class Hunter : MonoBehaviour
{
    internal List<Vector3> Clues;

    internal bool HasPrey;
    
    private NavMeshAgent _agent;
    private Random _random;
    private GameObject _activePrey;
    private float _timer;
    
    void Start()
    {
        Clues = new List<Vector3>();
        
        _random = new Random();
        
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        Coin.OnCoinCollected += cluePosition => Clues.Add((Vector3)cluePosition);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Prey")) return;
        
        HasPrey = true;
        _activePrey = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Prey")) return;

        HasPrey = false;
        _activePrey = null;
    }
    
    internal void WanderAround()
    {
        //TODO: Create destination, set destination, wait amount of time
        float rndX = _random.Next(-60, 60);
        float rndY = _random.Next(-60, 60);
        
        Vector3 deltaPosition = new Vector3(rndX, rndY);
        _agent.Move(deltaPosition);
    }

    internal void InspectClue()
    {
        if (Clues.Count <= 0) return;
        
        _agent.SetDestination(Clues[0]);
        Clues.RemoveAt(0);
    }

    internal void ChasePrey()
    {
        _agent.SetDestination(_activePrey.transform.position);
    }
}
