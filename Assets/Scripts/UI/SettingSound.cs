using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingSound : MonoBehaviour
{
    bool _playMusic = true;
    public Slider Musick_Slider;
    public Slider Sound_Slider;
    public AudioMixer mixer;
    [SerializeField] float Musick_Slider_volue = 0;
    [SerializeField] float Sound_Slider_volue = 0;
    [SerializeField] int N_Track = 0;
    int sizeList;
    // Start is called before the first frame update
    void Start()
    {
        Musick_Slider_volue = Musick_Slider.value;
        Sound_Slider_volue = Sound_Slider.value;
        sizeList =PlayerPrefs.GetInt("sizeListMusic");
        if (PlayerPrefs.GetInt("TrackN") != null)
        {
            N_Track = PlayerPrefs.GetInt("TrackN");
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpDateSettingSound();
    }
    void UpDateSettingSound()
    { 
        if (Musick_Slider.value!= Musick_Slider_volue)
        {
            Musick_Slider_volue = Musick_Slider.value;
            PlayerPrefs.SetFloat("Musick_Slider_volue", Musick_Slider_volue);
        }
        if (Sound_Slider.value != Sound_Slider_volue)
        {
            Sound_Slider_volue = Sound_Slider.value;
            //!!!!!!!!!!!!!!!!
            //mixer.Group.Master.FX.value=Sound_Slider_volue;
            PlayerPrefs.SetFloat("Sound_Slider_volue", Sound_Slider_volue);
        }
        if (Input.GetKey(KeyCode.P))
        {
            PlayStopMusick();
        }
        if (Input.GetKey(KeyCode.N))
        {
            NextMusic();
        }
        if (Input.GetKey(KeyCode.B))
        {
            BeckMusic();
        }
    }
    public void NextMusic()
    {
        if (sizeList > 0)
        {
            if (N_Track >= sizeList - 1)
            {
                N_Track = 0;
                SelecktTrack();
            }
            else
            {
                N_Track++;
                SelecktTrack();
            }
        }
    }
    public void BeckMusic()
    {
        if (sizeList > 0)
        {
            if (N_Track <= 0)
            {
                N_Track = sizeList - 1;
                SelecktTrack();
            }
            else
            {
                N_Track--;
                SelecktTrack();
            }
        }
    }
    public void PlayStopMusick()
    {
        if (_playMusic)
        {
            _playMusic = false;
        }
        else
        {
            _playMusic = true;
        }
        if(_playMusic)
        {
            PlayerPrefs.SetInt("PlayStopMusick", 1);
        }
        else
        {
            PlayerPrefs.SetInt("PlayStopMusick", 0);
        }
        if (PlayerPrefs.GetInt("TrackN") !=null)
        {
            if(N_Track != PlayerPrefs.GetInt("TrackN"))
            N_Track = PlayerPrefs.GetInt("TrackN");

        }
    }
   
    void SelecktTrack()
    {
        PlayerPrefs.SetInt("TrackN", N_Track);
    }
}
