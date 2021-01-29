using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Coin : MonoBehaviour
{
    [SerializeField] private int value;

    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Prey")) return;
        
        GameManager.Instance.SetScore(value);
        
        if(!_audio.isPlaying)
            _audio.Play();
        
        Destroy(gameObject);
    }
}
