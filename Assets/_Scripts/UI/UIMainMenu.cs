using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    public void Play()
    {
        GameSceneManager.instance.LoadScene(Constant.SCENE_GAME);
    }
    public void Quit()
    {
        GameSceneManager.instance.QuitGame();
    }
}
