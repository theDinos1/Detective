using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AladinNPC : MonoBehaviour
{
    public void GameOver()
    {
        GameSceneManager.Instance.LoadScene("over");
    }
}
