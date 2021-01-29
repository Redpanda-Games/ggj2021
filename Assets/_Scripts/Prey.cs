using UnityEngine;

public class Prey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.gameObject.CompareTag("Hunter")) return;
        
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameManager.Instance.RemovePrey(this);
    }
}
