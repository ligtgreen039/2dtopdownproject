using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class wave
{
    public string WaveName;
    public int numberofenemies;
    public int numberofdemon;
    public int numberofdragon;
    public int numberofzombie;
    public GameObject[] typeofenemies;
    public float spawnInterval;    
}
public class wavespawnerupgraded : MonoBehaviour
{
    public wave[] waves;
    private wave currentwave;
    public int currentwavenumber;
    private bool canspawn;
    private float spawntime;
    private int neededtospawnzombie = 20;
    public bool canspawnnormalize =true;
    public GameObject bilgiler;
    public Animator wavetext;
    public bool texttrigger;
    public GameObject market;
    private bool canactive;
    public float dragonspawntime;
    public bool canspawndragon = true;
    public float dragondelay;
    private void Start()
    {
        currentwave = waves[currentwavenumber];
        spawntime = currentwave.spawnInterval;
        dragonspawntime = 3 * currentwave.spawnInterval;
    }
    private void Update()
    {
        currentwave = waves[currentwavenumber];
        spawnvawe();
        markettrigger();
        continuegame();
        dragondelay = 4 * currentwave.spawnInterval;
        
    }
    private void spawnvawe()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        if(currentwave.numberofenemies == 0)
        {

            canspawnnormalize = false;
            canspawndragon = false;
            if (currentwavenumber == 10)
            {
                SceneManager.LoadScene(5);
            }
            else
            {
                if (enemies.Length == 0 && texttrigger == false)
                {
                    wavetext.SetTrigger("wavestarting");
                    texttrigger = true;
                    currentwavenumber += 1;
                }
            }
        }
        spawntime -= Time.deltaTime;
        dragonspawntime -= Time.deltaTime;
        if (dragonspawntime <= 0 && currentwave.numberofdragon > 0 && canspawndragon == true)
        {
            spawntime = currentwave.spawnInterval;
            Instantiate(currentwave.typeofenemies[1], new Vector3(-19, Random.Range(-10, 14), -10), Quaternion.identity);
            Instantiate(currentwave.typeofenemies[1], new Vector3(Random.Range(-18, 18), 13, -10), Quaternion.identity);
            Instantiate(currentwave.typeofenemies[1], new Vector3(Random.Range(-18, 18), -10, -10), Quaternion.identity);
            Instantiate(currentwave.typeofenemies[1], new Vector3(18, Random.Range(-10, 14), -10), Quaternion.identity);
            dragonspawntime =  (4 * currentwave.spawnInterval) - 0.01f;
            currentwave.numberofdragon -= 4;
            currentwave.numberofenemies -= 4;
        }
        if (currentwave.numberofdemon > 0 && spawntime <= 0 && canspawnnormalize == true)
        {
            Instantiate(currentwave.typeofenemies[0], new Vector3(-19, Random.Range(-10, 14), -10), Quaternion.identity);
            Instantiate(currentwave.typeofenemies[0], new Vector3(Random.Range(-18, 18), 13, -10), Quaternion.identity);
            Instantiate(currentwave.typeofenemies[0], new Vector3(Random.Range(-18, 18), -10, -10), Quaternion.identity);
            Instantiate(currentwave.typeofenemies[0], new Vector3(18, Random.Range(-10, 14), -10), Quaternion.identity);
            currentwave.numberofdemon -= 4;
            currentwave.numberofenemies -= 4;
            spawntime = currentwave.spawnInterval;
            neededtospawnzombie -= 4;
            if (currentwave.numberofzombie > 0 && neededtospawnzombie <= 0) 
            {
                canspawn = true;
                canspawnnormalize = false;
            }

        }
        if (spawntime <= 0 && canspawn == true)
        {
            Instantiate(currentwave.typeofenemies[2], new Vector3(-19, Random.Range(-10, 14), -10), Quaternion.identity);
            Instantiate(currentwave.typeofenemies[2], new Vector3(Random.Range(-18, 18), 13, -10), Quaternion.identity);
            Instantiate(currentwave.typeofenemies[2], new Vector3(Random.Range(-18, 18), -10, -10), Quaternion.identity);
            Instantiate(currentwave.typeofenemies[2], new Vector3(18, Random.Range(-10, 14), -10), Quaternion.identity);
            spawntime = currentwave.spawnInterval;
            currentwave.numberofzombie -= 4;
            currentwave.numberofenemies -= 4;
            canspawn = false;
            canspawnnormalize = true;
            neededtospawnzombie = 20;
        }
        

    }
    void markettrigger()
    {
        if ((currentwavenumber == 2 || currentwavenumber== 4 || currentwavenumber == 6 || currentwavenumber == 8) && canactive == false)
        {
            canactive = true;
            market.SetActive(true);
            GameObject.Find("bilgiler").SetActive(false);
            Time.timeScale = 0;
            charactercontroller.panelclosed = false;
        }
        if (currentwavenumber == 3 || currentwavenumber == 5 || currentwavenumber == 7 || currentwavenumber == 9)
        {
            canactive = false;
        }
    }
    public void continuegame()
    {
        if (market.activeSelf == false)
        {
            bilgiler.SetActive(true);
        }
    }

}

