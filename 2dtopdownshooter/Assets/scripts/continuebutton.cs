using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continuebutton : MonoBehaviour
{
    public Animator wavetext;
    public wavespawnerupgraded wavespawnerupgraded;
    public GameObject bilgiler;
    public enemycontroller enemycontroller;
    public charactercontroller charactercontroller;
    public void continuegame()
    {
        Time.timeScale = 1;
        GameObject.Find("market").SetActive(false);
        bilgiler.SetActive(true);
        wavetext.SetTrigger("wavestarting");
        wavespawnerupgraded.texttrigger = true;
        charactercontroller.panelclosed = true;
    }
    public void buyshotgun()
    {
        if (enemycontroller.para >= 500)
        {
            charactercontroller.canswitchshotgun = true;
            enemycontroller.para -= 500;
        }
    }
    public void buyshotgunammo()
    {
        if (enemycontroller.para >= 150)
        {
            charactercontroller.shotgunbulletamount += 30;
            enemycontroller.para -= 150;
        }
    }
    public void shotgundamageup()
    {
        if(enemycontroller.para >= 350)
        {
            enemycontroller.shotgundamage *= 2f;
            enemycontroller.para -= 350;
        }
    }
}
