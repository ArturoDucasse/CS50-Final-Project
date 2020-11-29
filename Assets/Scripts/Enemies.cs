using Unity.Mathematics;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject player;
    private UI ui;
    public float speed;
    public AudioClip playerHit;
    public AudioClip enemyHit;
    public AudioSource AudioSource;
    public ParticleSystem ParticleSystem;
    private int timer = 40;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        ui = GameObject.Find("Canvas").GetComponent<UI>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position,speed * Time.deltaTime);
        if (Time.time > timer)
        {
            speed++;
            timer += 40;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            {
                ui.HeartsLeft();
                AudioSource.PlayClipAtPoint(playerHit, Camera.main.transform.position,30f);
            }
            else if (other.CompareTag("Bullet"))
            {
                UI.points++;
                AudioSource.PlayClipAtPoint(enemyHit,Camera.main.transform.position, .5f);
                Destroy(other.gameObject);
            }
            Instantiate(ParticleSystem, transform.position, quaternion.identity);
            Destroy(gameObject);
    }
}
