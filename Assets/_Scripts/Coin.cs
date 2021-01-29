using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Coin : MonoBehaviour
{
    public delegate void SingleArgumentEvent(object o);
    public static event SingleArgumentEvent OnCoinCollected;
    
    [SerializeField] private int value;

    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Prey")) return;
        OnCoinCollected?.Invoke(transform.position);
        
        GameManager.Instance.SetScore(value);
        
        if(!_audio.isPlaying)
            _audio.Play();
        
        Destroy(gameObject);
    }
}
