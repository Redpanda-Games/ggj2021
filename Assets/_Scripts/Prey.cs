using UnityEngine;

public class Prey : MonoBehaviour
{
    [SerializeField] private AudioClip[] sounds;
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GameManager.Instance.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.gameObject.CompareTag("Hunter")) return;

        if (!_audio.isPlaying)
            _audio.PlayOneShot(sounds[0]);
        
        Destroy(gameObject);
    }
}
