using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Reload()
    {
        // Destroy(GameObject.Find("GameManager"));
        //
        // int sceneToLoad = SceneManager.GetActiveScene().buildIndex;
        // SceneManager.LoadScene(sceneToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
