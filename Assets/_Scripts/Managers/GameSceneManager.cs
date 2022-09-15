using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;
    public GameData gameData { get; private set; }

    public bool firstTimeInGame = true;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        Initialize();
    }

    private void Initialize()
    {
        gameData = new GameData();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        switch (sceneName)
        {
            case Constant.SCENE_GAME:
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                break;
            case Constant.SCENE_MAINMENU:
                firstTimeInGame = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                break;
            default:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                break;
        }
    }
    public void LoadScene(string sceneName, float secondsToReturn)
    {
        StartCoroutine(ReturnInGame(sceneName, secondsToReturn));

    }

    private IEnumerator ReturnInGame(string sceneName, float seconds)
    {
        GameManager.Instance.HideEnvironment();
        SceneManager.LoadScene(sceneName,LoadSceneMode.Additive);
        yield return new WaitForSeconds(seconds);
        SceneManager.UnloadSceneAsync(sceneName);
        GameManager.Instance.ShowEnvironment();

    }

    public void SetCursorNormal()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void SetCursorLocked()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
public class GameData
{
    public Inventory inventory { get; set; }

    public GameData()
    {
        inventory = new Inventory();
    }
}
