using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyspawner : MonoBehaviour
{
    GameObject player;
    public GameObject enemy;
    public static int enemycounter = 0;
    float gerisayim = 4f;
    float wavearasi = 15f;
    int enemyforwave = 16;
    public int wave = 1;
    float azalangerisayim = 4f;
    int  enemysayisi = 0;
    float gerisayiminfinity = 4f;
    public GameObject market;
    bool canactive;
    public GameObject bilgiler;
    public Animator wavetext;
    public bool texttrigger;
    public GameObject enemydragon;
    public GameObject enemyzombie;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if ((int)SceneManager.GetActiveScene().buildIndex == 1)
        {
            StartCoroutine(sayac(enemy));
        }

    }
    IEnumerator sayac(GameObject enemy)
    {
        if ((int)SceneManager.GetActiveScene().buildIndex == 1)
        {
            yield return new WaitForSeconds(gerisayiminfinity);
            if (gerisayiminfinity >= 1f)
            {
                gerisayiminfinity -= 0.1f;
            }
            GameObject newenemy = Instantiate(enemy, new Vector3(-19, Random.Range(-10, 14), -10), Quaternion.identity);
            GameObject newenemy2 = Instantiate(enemy, new Vector3(Random.Range(-18, 18), 13, -10), Quaternion.identity);
            GameObject newenemy3 = Instantiate(enemy, new Vector3(Random.Range(-18, 18), -10, -10), Quaternion.identity);
            GameObject newenemy4 = Instantiate(enemy, new Vector3(18, Random.Range(-10, 14), -10), Quaternion.identity);
            StartCoroutine(sayac(enemy));
        }
    }
    private void Update()
    {
        if ((int)SceneManager.GetActiveScene().buildIndex == 2)
        {
            vaweenemyspawner();
            markettrigger();
            continuegame();
        }
    }
    void vaweenemyspawner()
    {
        gerisayim -= Time.deltaTime;
        if (gerisayim <= 0)
        {
            gerisayim = azalangerisayim;
            enemysayisi += 4;
            int sans = Random.Range(1, 21);
            if(sans < 12)
            {
                Instantiate(enemy, new Vector3(-19, Random.Range(-10, 14), -10), Quaternion.identity);
                Instantiate(enemy, new Vector3(Random.Range(-18, 18), 13, -10), Quaternion.identity);
                Instantiate(enemy, new Vector3(Random.Range(-18, 18), -10, -10), Quaternion.identity);
                Instantiate(enemy, new Vector3(18, Random.Range(-10, 14), -10), Quaternion.identity);
            }
            if (sans > 12 && sans < 16)
            {
                Instantiate(enemyzombie, new Vector3(-19, Random.Range(-10, 14), -10), Quaternion.identity);
                Instantiate(enemyzombie, new Vector3(Random.Range(-18, 18), 13, -10), Quaternion.identity);
                Instantiate(enemyzombie, new Vector3(Random.Range(-18, 18), -10, -10), Quaternion.identity);
                Instantiate(enemyzombie, new Vector3(18, Random.Range(-10, 14), -10), Quaternion.identity);
            }
            if (sans > 16)
            {
                Instantiate(enemydragon, new Vector3(-19, Random.Range(-10, 14), -10), Quaternion.identity);
                Instantiate(enemydragon, new Vector3(Random.Range(-18, 18), 13, -10), Quaternion.identity);
                Instantiate(enemydragon, new Vector3(Random.Range(-18, 18), -10, -10), Quaternion.identity);
                Instantiate(enemydragon, new Vector3(18, Random.Range(-10, 14), -10), Quaternion.identity);
            }
        }
        if(enemysayisi >= enemyforwave)
        {
            azalangerisayim -= 0.3f;
            gerisayim = wavearasi;
            enemyforwave += 16;
            wave += 1;
            enemysayisi = 0;
        }
        if(wave == 11)
        {
            SceneManager.LoadScene(5);
        }
        if (gerisayim <= 5.31f && gerisayim >= 5.29f && texttrigger == false)
        {
            wavetext.SetTrigger("wavestarting");
            texttrigger = true;
        }
    }
    void markettrigger()
    {
        if ((wave == 3 || wave == 5 || wave == 7 || wave == 9) && canactive == false)
        {
            canactive = true;
            market.SetActive(true);
            GameObject.Find("bilgiler").SetActive(false);
            Time.timeScale = 0;
        }
        if(wave == 4 || wave == 6 || wave == 8 || wave == 10)
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
