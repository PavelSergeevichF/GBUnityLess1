using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    static int numSize = 14;
    public int[] bullet = new int[numSize];
    int[] bulletMax = new int[numSize];
    int[] bulletGet = new int[numSize];
    public int[] loadWeapon = new int[numSize];
    public int[] timeLoadWeapon = new int[numSize];
    public int[] powerWeapon = new int[numSize];
    public int SizeSelect = 1;
    public bool[] weapon = new bool[numSize];//4гранаты(10-13) 10 оружие (0-9)
    public string[] nameTakeObj =new string[numSize];
    public string[] nameTakeWeapon = new string[numSize];
    public int SetActivWeapon;
    float scrollDate = 0;
    int sliderRedyActiv;
    public Slider sliderRedy;
    WeaponPanel weaponPanel;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numSize; i++) weapon[i] = false;
        weaponPanel = GameObject.Find("WeaponPanel").GetComponent<WeaponPanel>();
        SetMaxBull();
        SetTakeBull();
        SetTimeLoad();
        SetActivWeapon = 10;
        int j = 0;
        for(int i=0;i< numSize;i++) { loadWeapon[i]=0; }
        sliderRedyActiv = SetActivWeapon;
        sliderRedy.maxValue = timeLoadWeapon[SetActivWeapon];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        setSlider();
        charge();
        SetWeapon();
        weaponPanel.weapon = SetActivWeapon;
    }
    void SetWeapon()
    {
        scrollDate += Input.GetAxis("Mouse ScrollWheel")* SizeSelect;
        if (scrollDate > numSize - 1) scrollDate -= numSize;
        if (scrollDate < 0) scrollDate += numSize;
        SetActivWeapon = (int)scrollDate;
    }
    void charge()
    {
        for(int i=0;i< numSize;i++)
        {
            if (loadWeapon[i] < timeLoadWeapon[i] && bullet[i] > 0) loadWeapon[i]++;
            
        }
        sliderRedy.value = loadWeapon[sliderRedyActiv];
    }
    void setSlider()
    {
        if (sliderRedyActiv == SetActivWeapon) return;
        sliderRedyActiv = SetActivWeapon;
        sliderRedy.maxValue = timeLoadWeapon[SetActivWeapon];
    }
    public void GetObj(string nameObj)
    {
        for (int i = 0; i < nameTakeObj.Length; i++)
        {
            if (nameObj== nameTakeObj[i])
            {
                bullet[i] += bulletGet[i];
                if (bullet[i] > bulletMax[i]) bullet[i] = bulletMax[i];
            }
        }
        for (int i = 0; i < nameTakeWeapon.Length; i++)
        {
            if (nameObj == nameTakeWeapon[i])
            {
                if (!weapon[i]) weapon[i] = true;
            }
        }
    }
    
    void SetMaxBull()
    {
        bulletMax[0] = 100; bulletMax[1]  = 50;  bulletMax[2]  = 250; bulletMax[3]  = 300; bulletMax[4] = 50;
        bulletMax[5] = 30;  bulletMax[6]  = 500; bulletMax[7]  = 400; bulletMax[8]  = 10;  bulletMax[9] = 8;
        bulletMax[10] = 20; bulletMax[11] = 20;  bulletMax[12] = 15;  bulletMax[13] = 10; 
    }
    void SetTakeBull()
    {
        bulletGet[0]  = 10; bulletGet[1]  = 5;  bulletGet[2]  = 25; bulletGet[3]  = 30; bulletGet[4] = 7;
        bulletGet[5]  = 5;  bulletGet[6]  = 40; bulletGet[7]  = 35; bulletGet[8]  = 1;  bulletGet[9] = 1;
        bulletGet[10] = 1;  bulletGet[11] = 1;  bulletGet[12] = 1;  bulletGet[13] = 1;
    }
    void SetTimeLoad()
    {
        timeLoadWeapon[0]= 40; timeLoadWeapon[1]= 35; timeLoadWeapon[2]= 3; timeLoadWeapon[3]= 5; timeLoadWeapon[4]= 60;
        timeLoadWeapon[5]= 80; timeLoadWeapon[6]= 6; timeLoadWeapon[7]= 10; timeLoadWeapon[8]= 90; timeLoadWeapon[9]= 110;
        timeLoadWeapon[10]= 60; timeLoadWeapon[11]= 60; timeLoadWeapon[12]= 50; timeLoadWeapon[13]= 50;
    }
    void WeaponName()
    {
        //0-пистолет
        //1-пистолет
        //2-автомат
        //3-автомат
        //4-дробавик
        //5-дробавик
        //6-пулимет
        //7-пулимет
        //8-ракетница
        //9-ракетница
        //10-граната
        //11-граната
        //12-граната
        //13-граната
    }
}
