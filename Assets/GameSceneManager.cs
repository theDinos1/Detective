using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        switch (sceneName)
        {
            case "SceneGameLevel1":
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Confined;
                break;
            default:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                break;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
