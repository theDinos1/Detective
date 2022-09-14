using UnityEngine;

public class NPCFunctions : MonoBehaviour
{
    public void GameOver()
    {
        GameSceneManager.instance.LoadScene(Constant.SCENE_GAMEOVER);
    }
    public void GameWin()
    {
        GameSceneManager.instance.LoadScene(Constant.SCENE_GAMEWIN);
    }
    public void SetPlayerOnDialog()
    {
        GameSceneManager.instance.SetCursorNormal();
        PlayerController.myPlayer.SetCanMoveFalse();
    }
    public void SetPlayerOffDialog()
    {
        GameSceneManager.instance.SetCursorLocked();
        PlayerController.myPlayer.SetCanMoveTrue();
    }
}
