using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemGame : MonoBehaviour
{
    public GameObject MenuConvas;
    public GameObject GameConvas;
    public GameObject SettingConvas;
    [SerializeField] bool _menu = false;
    int timeDelay = 30;
    bool getData = true;
    bool _backInput = false;
    float _time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        ActivGame();

        _time=Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!getData && timeDelay > 0) timeDelay--;
        else 
        { 
            getData = true; timeDelay = 30; 
        }
        if (Input.GetKey(KeyCode.Escape)|| _backInput)
        {
            _backInput = false;
            if (!_menu && getData)
            {
                getData = false;
                _menu = true; 
            }
            if (_menu && getData) 
            {
                getData = false;
                _menu = false;
                Cursor.visible = false;
            }
            ActivMenu();
        }
        if (Input.GetKey(KeyCode.O)) { Application.Quit(); Debug.Log("Quit"); }
    }  
    void ClearConvas()
    {
        MenuConvas.SetActive(false);
        GameConvas.SetActive(false);
        SettingConvas.SetActive(false);
    }
    void ActivMenu()
    {
        ClearConvas();
        Cursor.visible = true;// включаем отображение курсора
        if (_menu) Time.timeScale = 0;
        else Time.timeScale = _time;
        MenuConvas.SetActive(_menu);
        GameConvas.SetActive(!_menu);
    }
    void ActivGame()
    {
        ClearConvas();
        GameConvas.SetActive(true);
    }
    public void Back()
    {
        _backInput = true;
    }
    public void GoBackFromSettings()
    {
        SettingConvas.SetActive(false);
    }
    public void GoFromSettings()
    {

        Cursor.visible = true;
        SettingConvas.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
