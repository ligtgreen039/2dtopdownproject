using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class charactercontroller : MonoBehaviour
{
    public Rigidbody2D crb;
    public Animator charanimator;
    public Animator feetanimator;
    Vector2 dir;
    public GameObject bulletplace;
    public GameObject bullet;
    GameObject mybullet;
    public int pistolbulletcounter = 30;
    bool reloading = false;
    public static float shaketimeremaining;
    float shakepower;
    public GameObject maincamera;
    float movespeed = 5;
    float activemovespeed;
    float dashtime = 0.2f;
    float dashcooldown = 0;
    public AudioClip gunshotsound;
    public AudioClip dashsound;
    public AudioClip reloadsound;
    bool canreload = true;
    public string reloadanm;
    public string fireanm;
    public GameObject riflebullet;
    public GameObject grenade;
    public AudioClip pistolsound;
    public AudioClip pistolreload;
    public AudioClip shotgunreload;
    public AudioClip shotgunfire;
    public float explosionammo = 1;
    public AudioClip explosiveammoshot;
    public string gunname;
    public int riflebulletcounter = 30;
    bool riflereloading;
    public int riflebulletamount = 0;
    public bool canswitchrifle;
    float decaytime = 1f;
    bool cantswitchweapon;
    public static bool panelclosed = true;
    bool shotgunreloading;
    public bool canswitchshotgun;
    public int shotgunbulletamount = 0;
    public int shotgunbulletcounter = 12;
    public GameObject shotgunbullet;
    public GameObject shotgunbullet2;
    public GameObject shotgunbullet3;
    public GameObject shotgunbullet4;
    public GameObject shotgunbullet5;
    void Update()
    {
        movefonc();
        followmouse();
        fire();
        dash();
        throwgrenade();
        switchweapon();
    }
    private void Start()
    {
        activemovespeed = movespeed;
        if ((int)SceneManager.GetActiveScene().buildIndex == 2)
        {
            reloadanm = "handgunreload";
            fireanm = "handgunfire";

        }
        else if ((int)SceneManager.GetActiveScene().buildIndex == 1)
        {
            reloadanm = "reload";
            fireanm = "fire";

        }
        gunname = "Pistol";

    }
    private void LateUpdate()
    {
        shakefonction();
    }
    void movefonc()
    {
        float velocityx = Input.GetAxis("Horizontal");
        float velocityy = Input.GetAxis("Vertical");
        crb.velocity = new Vector2(velocityx, velocityy) * activemovespeed;
        charanimator.SetFloat("velocity", crb.velocity.magnitude);
        feetanimator.SetFloat("velocity", crb.velocity.magnitude);
    }
    void followmouse()
    {
        dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg - 95;
        crb.rotation = -angle;
    }
    void fire()
    {
        reload();
        if (Input.GetMouseButtonDown(0) && panelclosed == true)
        {
            if (pistolbulletcounter <= 0)
            {
                reloading = true;
            }
            if (riflebulletcounter <= 0)
            {
                riflereloading = true;
            }
            if(shotgunbulletcounter <= 0)
            {
                shotgunreloading = true;
            }
            if (reloading == false && reloadanm == "handgunreload")
            {
                GameObject.Find("soundcontroller").GetComponent<AudioSource>().PlayOneShot(pistolsound);
                startshake(0.1f, 0.2f);
                mybullet = Instantiate(bullet, bulletplace.transform.position, Quaternion.identity);
                pistolbulletcounter -= 1;
                mybullet.transform.up = transform.up;
                charanimator.SetTrigger(fireanm);
                Rigidbody2D rb = mybullet.GetComponent<Rigidbody2D>();
                rb.AddForce(bulletplace.transform.up * 30, ForceMode2D.Impulse);
            }
            else if (riflereloading == false && reloadanm == "reload")
            {
                GameObject.Find("rifleshotsound").GetComponent<AudioSource>().PlayOneShot(gunshotsound);
                startshake(0.1f, 0.2f);
                mybullet = Instantiate(riflebullet, bulletplace.transform.position, Quaternion.identity);
                riflebulletcounter -= 1;
                mybullet.transform.up = transform.up;
                charanimator.SetTrigger(fireanm);
                Rigidbody2D rb = mybullet.GetComponent<Rigidbody2D>();
                rb.AddForce(bulletplace.transform.up * 30, ForceMode2D.Impulse);
            }
            else if (shotgunreloading == false && reloadanm == "shotgunreload")
            {
                GameObject.Find("soundcontroller").GetComponent<AudioSource>().PlayOneShot(shotgunfire);
                startshake(0.1f, 0.2f);
                Instantiate(shotgunbullet, bulletplace.transform.position, Quaternion.identity);
                Instantiate(shotgunbullet2, bulletplace.transform.position, Quaternion.identity);
                Instantiate(shotgunbullet3, bulletplace.transform.position, Quaternion.identity);
                Instantiate(shotgunbullet4, bulletplace.transform.position, Quaternion.identity);
                Instantiate(shotgunbullet5, bulletplace.transform.position, Quaternion.identity);
                shotgunbulletcounter -= 1;
                charanimator.SetTrigger(fireanm);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            if ((int)SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            if ((int)SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene(4);
            }
            Time.timeScale = 0;
            enabled = false;
        }
    }

    void startshake(float lenght, float power)
    {
        shaketimeremaining = lenght;
        shakepower = power;

    }
    void shakefonction()
    {
        if (shaketimeremaining > 0)
        {
            shaketimeremaining -= Time.deltaTime;
            float xamount = Random.Range(-0.5f, 0.5f) * shakepower;
            float yamount = Random.Range(-0.5f, 0.5f) * shakepower;
            maincamera.transform.position += new Vector3(xamount, yamount, 0f);
        }
    }
    void dash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dashcooldown <= 0)
        {
            GameObject.Find("soundcontroller").GetComponent<AudioSource>().PlayOneShot(dashsound);
            dashtime = 0.11f;
            dashcooldown = 3;
        }
        if (dashtime <= 0)
        {
            activemovespeed = movespeed;
        }
        if (dashtime >= 0)
        {
            activemovespeed = 20;
            dashtime -= Time.deltaTime;
        }
        dashcooldown -= Time.deltaTime;
    }
    void reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && canreload == true)
        {
            canreload = false;
            reloading = true;
            cantswitchweapon = true;
            riflereloading = true;
            shotgunreloading = true;
            charanimator.SetTrigger(reloadanm);
        }
    }
    void throwgrenade()
    {
        decaytime -= Time.deltaTime;
        if (Input.GetMouseButtonDown(1) && explosionammo > 0 && decaytime <= 0)
        {
            if (reloading == false || riflereloading == false)
            {
                GameObject.Find("soundcontroller").GetComponent<AudioSource>().PlayOneShot(explosiveammoshot);
                charanimator.SetTrigger(fireanm);
                explosionammo -= 1;
                GameObject grenade1 = Instantiate(grenade, bulletplace.transform.position, Quaternion.identity);
                grenade1.transform.up = transform.up;
                decaytime = 1f;
            }
        }

    }
    void controller()
    {
        reloading = false;
        riflereloading = false;
        canreload = true;
        shotgunreloading = false;
        cantswitchweapon = false;
        if (reloadanm == "handgunreload")
        {
            pistolbulletcounter = 30;
        }
        if(riflebulletamount>= 30 && reloadanm == "reload")
        {
            riflebulletcounter = 30;
            riflebulletamount -= 30;
        }
        if(reloadanm == "shotgunreload" && shotgunbulletamount >= 12)
        {
            shotgunbulletcounter = 12;
            shotgunbulletamount -= 12;
        }
    }
    void reloadsounstarter()
    {
        if (reloadanm == "handgunreload")
        {
            GameObject.Find("soundcontroller").GetComponent<AudioSource>().PlayOneShot(pistolreload);
        }
        if (reloadanm == "reload")
        {
            GameObject.Find("soundcontroller").GetComponent<AudioSource>().PlayOneShot(reloadsound);
        }
        if (reloadanm == "shotgunreload")
        {
            GameObject.Find("soundcontroller").GetComponent<AudioSource>().PlayOneShot(shotgunreload);
        }
    }
    void switchweapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && reloadanm != "handgunreload" && cantswitchweapon == false)
        {
            fireanm = "handgunfire";
            reloadanm = "handgunreload";
            charanimator.SetTrigger("gunswitch");
            gunname = "Pistol";

        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && reloadanm != "reload" && canswitchrifle == true && cantswitchweapon == false)
        {
            fireanm = "fire";
            reloadanm = "reload";
            charanimator.SetTrigger("rifleswitch");
            gunname = "Rifle";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && reloadanm != "shotgunreload" && cantswitchweapon == false) 
        {
            fireanm = "shotgunfire";
            reloadanm = "shotgunreload";
            charanimator.SetTrigger("shotgunswitch");
            gunname = "Shotgun";
        }
          
    }
}
