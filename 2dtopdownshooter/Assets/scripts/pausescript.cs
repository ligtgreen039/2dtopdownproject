using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pausescript : MonoBehaviour
{
    public GameObject pausemenu;
    public GameObject settings;
    public Slider volumebar;
    public GameObject sounds;
    public GameObject riflesounds;
    const string volume_value_ = "value";
    private void Start()
    {
        PlayerPrefs.GetFloat(volume_value_);
        volumebar.value = PlayerPrefs.GetFloat(volume_value_);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pausemenu.activeSelf == false && settings.activeSelf == false)
        {
            pausemenu.SetActive(true);
            Time.timeScale = 0f;
            charactercontroller.panelclosed = false;
            charactercontroller.shaketimeremaining = 0f;
        }
        PlayerPrefs.SetFloat(volume_value_, volumebar.value);
        AudioListener.volume = PlayerPrefs.GetFloat(volume_value_);

    }
    public void exitfonc()
    {
        Application.Quit();
    }
    public void returnmenufonc()
    {
        SceneManager.LoadScene(0);
    }
    public void resumefonc()
    {
        Time.timeScale = 1f;
        pausemenu.SetActive(false);
        charactercontroller.panelclosed = true;
        PlayerPrefs.SetFloat(volume_value_, volumebar.value);
    }
    public void settingsbutton()
    {
        pausemenu.SetActive(false);
        settings.SetActive(true);
    }
    public void backbutton()
    {
        pausemenu.SetActive(true);
        settings.SetActive(false);
    }
}
