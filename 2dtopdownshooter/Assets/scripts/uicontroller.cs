using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uicontroller : MonoBehaviour
{
    public Text mermitext;
    public charactercontroller charactercontroller;
    float saniye = 0;
    public Text saniyetext;
    public Text paratext;
    public enemycontroller enemycontroller;
    public Text wavetext;
    public wavespawnerupgraded wavespawnerupgraded;
    public Text marketparasi;
    public Text explosivemermi;
    public Text guntext;
    void Update()
    {
        mermiequalizer();
        secondequalizer();
        waveequalizer();
        paraequalizer();
        explosiveequaliser();
    }
    void secondequalizer()
    {
        saniye += Time.deltaTime;
        saniyetext.text = ((int)saniye).ToString();
    }
    void paraequalizer()
    {
     paratext.text = enemycontroller.para.ToString();
     if ((int)SceneManager.GetActiveScene().buildIndex == 2)
     {
      marketparasi.text = enemycontroller.para.ToString();
     }
    }
    void waveequalizer()
    {
        if ((int)SceneManager.GetActiveScene().buildIndex == 2)
        {
            wavetext.text = (wavespawnerupgraded.currentwavenumber+1).ToString();

        }
    }
    void mermiequalizer()
    {
        guntext.text = charactercontroller.gunname.ToString();
        if(charactercontroller.gunname == "Pistol")
        {
            mermitext.text = charactercontroller.pistolbulletcounter.ToString();
        }
        if(charactercontroller.gunname == "Rifle")
        {
            mermitext.text = charactercontroller.riflebulletcounter.ToString();
        }
        if(charactercontroller.gunname == "Shotgun")
        {
            mermitext.text = charactercontroller.shotgunbulletcounter.ToString();
        }
    }
    void explosiveequaliser()
    {
        explosivemermi.text = charactercontroller.explosionammo.ToString();
    }
}
