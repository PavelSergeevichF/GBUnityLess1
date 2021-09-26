using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource[] track;
    [SerializeField] int N_Track = 0;
    [SerializeField] float Musick_Slider_volue = 0;
    [SerializeField] float Sound_Slider_volue = 0;
    [SerializeField] bool _Play;
    [SerializeField] bool _CheckPlay=true;
    [SerializeField] bool _CheckSPlay = true;
    int _volMusic;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("sizeListMusic", track.Length);
        N_Track = PlayerPrefs.GetInt("TrackN");
        if (PlayerPrefs.GetInt("PlayStopMusick") == 0)
            _Play = false;
        else _Play = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDataMusic();
    }
    void CheckDataMusic()
    {
        if (PlayerPrefs.GetInt("PlayStopMusick") == 0 && _Play)
            _Play = false;
        if(PlayerPrefs.GetInt("PlayStopMusick") != 0 && !_Play)
            _Play = true;
        if(_Play&& _CheckPlay)
        {
            _CheckPlay = false;
            _CheckSPlay = true;
            track[N_Track].Play();
        }
        if (!_Play && _CheckSPlay)
        {
            _CheckSPlay = false;
            _CheckPlay = true;
            StopTrack();
        }
        if (N_Track != PlayerPrefs.GetInt("TrackN"))
        { 
            N_Track = PlayerPrefs.GetInt("TrackN");
            SelecktTrack();
        }
        if (PlayerPrefs.GetFloat("Musick_Slider_volue") != Musick_Slider_volue)
        {
            Musick_Slider_volue = PlayerPrefs.GetFloat("Musick_Slider_volue");
        }
        if (PlayerPrefs.GetFloat("Sound_Slider_volue") != Sound_Slider_volue)
        {
            Sound_Slider_volue = PlayerPrefs.GetFloat("Sound_Slider_volue");
        }
    }
    void StopTrack()
    {
        for (int i = 0; i < track.Length; i++)
        { track[i].Stop(); }
    }
    void SelecktTrack()
    {
        StopTrack();
        track[N_Track].Play();
    }
}
