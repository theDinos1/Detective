using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _Environment;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public void ShowEnvironment()
    {
        _Environment.ForEach(i=> i.SetActive(true));
    }

    public void HideEnvironment()
    {
        _Environment.ForEach(i => i.SetActive(false));
    }
}
