using System;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private float _StartCoolDown;
    [SerializeField] private TMP_Text _CDText;
    private float _CoolDown;
    // Start is called before the first frame update
    void Start()
    {
        _CoolDown = _StartCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (_CoolDown > 0)
        {
            _CoolDown -= Time.deltaTime;
            _CDText.text = Convert.ToInt32(_CoolDown).ToString();
        }
        else
        {
            GameSceneManager.Instance.LoadScene("Main Menu");
        }
    }
}
