using UnityEngine;

public class NoisyFloor : MonoBehaviour
{
    public static event Coin.SingleArgumentEvent OnMakeNoise; 
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Prey")) return;
        
        if(!_audio.isPlaying)
            _audio.Play();
        
        OnMakeNoise?.Invoke(transform.position);
    }
}
