using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scenemanager : MonoBehaviour
{
    private static bool created = false;
    float score = 0;
    public enemycontroller enemycontroller;
    Text scoretext;
    Text numbertext;
    charactercontroller charactercontroller;
    int olendusmanlar;
    private void Awake()
    {
        Time.timeScale = 1;
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        charactercontroller = GameObject.Find("player").GetComponent<charactercontroller>();
    }
    private void Update()
    {
        scoreequalizer();
    }
    void scoreequalizer()
    {
        if ((int)SceneManager.GetActiveScene().buildIndex == 1 || (int)SceneManager.GetActiveScene().buildIndex == 2)
        {
            score = enemycontroller.para;
            olendusmanlar = enemycontroller.olendusmansayisi;
        }
        if ((int)SceneManager.GetActiveScene().buildIndex == 3 || (int)SceneManager.GetActiveScene().buildIndex == 4)
        {
            scoretext = GameObject.Find("scoretext").GetComponent<Text>();
            scoretext.text = score.ToString();
        }
        if ((int)SceneManager.GetActiveScene().buildIndex == 5)
        {
            numbertext = GameObject.Find("numbertext").GetComponent<Text>();
            numbertext.text = olendusmanlar.ToString();
        }
    }
    public void retrybutton_infinity()
    {
        enemycontroller.para = 0;
        SceneManager.LoadScene(1);
        enemycontroller.olendusmansayisi = 0;
    }
    public void retrybutton_wawed()
    {
        enemycontroller.para = 0;
        SceneManager.LoadScene(2);
        enemycontroller.olendusmansayisi = 0;
    }
    public void mainmenubutton()
    {
        enemycontroller.para = 0;
        SceneManager.LoadScene(0);
        enemycontroller.olendusmansayisi = 0;
    }
    public void startgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void infinitymode()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void quitgame()
    {
        Application.Quit();
    }
    public void purchaseexplosive()
    {
    if (enemycontroller.para>= 100)
       {
            charactercontroller = GameObject.Find("player").GetComponent<charactercontroller>();
            charactercontroller.explosionammo += 1;
            enemycontroller.para -= 100;
       }
    }
    public void buyrifleammo()
    {
        charactercontroller = GameObject.Find("player").GetComponent<charactercontroller>();
        if (enemycontroller.para >= 150)
        {
            charactercontroller.riflebulletamount += 30;
            enemycontroller.para -= 150;
        }
    }
    public void buyrifle()
    {
        charactercontroller = GameObject.Find("player").GetComponent<charactercontroller>();
        if (enemycontroller.para >= 250)
        {
            charactercontroller.canswitchrifle = true;
            enemycontroller.para -= 250;
        }
    }
}
