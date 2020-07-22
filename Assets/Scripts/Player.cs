using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float maxHP = 100f;
    public float timeBetweenShoots = 0.5f;

    public GameObject bulletPrefab;
    public Transform bulletOrigin;

    public Text hpText;

    public GameObject deadParticlePrefab;

    public AudioClip shootAudioClip;
    public AudioClip explosionPlayerAudioClip;

    private float currentHP;
    private float timeOfLastShoot;

    private void Start()
    {
        currentHP = maxHP;
        hpText.text = "HP: " + currentHP;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > timeOfLastShoot + timeBetweenShoots)
                Shoot();
        }
    }

    public void Damage(float amount)
    {
        currentHP -= amount;
        hpText.text = "HP: " + currentHP;

        if(currentHP <= 0f)
        {
            Dead();
        }
    }


    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);
        Destroy(bullet, 5f);
        timeOfLastShoot = Time.time;

        AudioSource.PlayClipAtPoint(shootAudioClip, transform.position, 0.7f);
    }

    private void Dead()
    {
        AudioSource.PlayClipAtPoint(explosionPlayerAudioClip, transform.position, 0.9f);

        Instantiate(deadParticlePrefab, transform.position, transform.rotation);

        FindObjectOfType<GameManager>().GameOver();

        Destroy(this.gameObject);
    }
}
