using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

[RequireComponent(typeof(NavMeshAgent))]
public class Hunter : MonoBehaviour
{
    internal List<Transform> Clues;

    internal bool HasPrey;
    
    private NavMeshAgent _agent;
    private Random _random;
    private GameObject _activePrey;
    
    void Start()
    {
        Clues = new List<Transform>();
        
        _agent = GetComponent<NavMeshAgent>();
        _random = new Random();

        Coin.OnCoinCollected += clueTransform => Clues.Add((Transform)clueTransform);
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
        Vector2 deltaPosition = new Vector2(_random.Next(5), _random.Next(5));
        _agent.Move(deltaPosition);
    }

    internal void InspectClue()
    {
        _agent.Move(Clues[0].position);
        Clues.Remove(Clues[0]);
    }

    internal void ChasePrey()
    {
        _agent.Move(_activePrey.transform.position);
    }
}
