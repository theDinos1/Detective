using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text _AlertText;
    public static UIHUD Instance;
    private bool _IsOpen = true;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        HideAlertText();
        if (GameSceneManager.instance.firstTimeInGame)
        {
            GameSceneManager.instance.gameData.inventory.InitailizeData();
            GameSceneManager.instance.firstTimeInGame = false;
        }
    }
    public void ShowAlertText(string text)
    {
        if (!_IsOpen)
        {
            _AlertText.text = text.ToUpper();
            _AlertText.transform.gameObject.SetActive(true);
            _IsOpen = true;
        }
    }
    public void HideAlertText()
    {
        if (_IsOpen)
        {
            _AlertText.text = string.Empty;
            _AlertText.transform.gameObject.SetActive(false);
            _IsOpen = false;
        }
        
    }
}
