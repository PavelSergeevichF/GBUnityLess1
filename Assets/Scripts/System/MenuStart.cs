using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    public GameObject InfoPanel;
    public GameObject SettinPanel;
    public Text InfoText;
    //public GameObject SoundPanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ClearPanel()
    {
        InfoPanel.SetActive(false);
        SettinPanel.SetActive(false);
        //SoundPanel.SetActive(false);
    }
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ContinuationButton()
    { }
    public void InfoButton()
    {
        ClearPanel();
        InfoPanel.SetActive(true);
        SetInfoText();
    }
    public void SettingsButton()
    {
        ClearPanel();
        SettinPanel.SetActive(true);
    }
    //public void SoundButton()
    //{
    //    ClearPanel();
    //    SoundPanel.SetActive(true);
    //}
    public void BackButton()
    {
        ClearPanel();
    }
    void SetInfoText()
    {
        InfoText.text= "Program code: Fedotov P S \nGame design: Fedotov P S \nLevel Design: Fedotov P S";
    }
}
