using UnityEngine;

public class Prey : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.gameObject.CompareTag("Hunter")) return;
        
        Destroy(gameObject);
    }
}
