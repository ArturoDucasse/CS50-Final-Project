using System;
using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    private double reload;
    private double hold = 0.5;
    public AudioClip shootSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (UI.gameOn)
        {
            LookMouse();
            if (Input.GetMouseButtonDown(0) && coolDown())
            {
                Shoot();
                reload = Time.time + hold;
            }
        }
    }

    /// <summary>
    /// Code from Unity C# - How to face the mouse position in 2D
    /// URL: https://www.youtube.com/watch?v=_XdqA3xbP2A
    /// </summary>
    private void LookMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        transform.up = direction;
    }

    private void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        audioSource.PlayOneShot(shootSound);
    }

    bool coolDown()
    {
        if (Time.time > reload)
        {
            return true;
        }
        return false;
    }
}
