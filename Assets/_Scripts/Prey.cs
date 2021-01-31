using UnityEngine;

public class Prey : MonoBehaviour
{
    [SerializeField] private AudioClip[] sounds;
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.gameObject.CompareTag("Hunter")) return;
        
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if(!_audio.isPlaying)
            _audio.PlayOneShot(sounds[0]);
    }
}
