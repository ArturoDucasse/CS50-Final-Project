using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public  GameObject[] hearts;
    public static int points = 0;
    private int heart = 2;
    public static bool gameOn;
    public GameObject startGameUI;
    public ParticleSystem ParticleSystem;
    public GameObject player;
    public TextMeshProUGUI score;
    public GameObject finalScore;
    public GameObject ingameScore;

    void Update()
    {
        pointsText.SetText("Points: " + points);
    }

    public void HeartsLeft()
    {
        hearts[heart].SetActive(false);
        heart--;
        if (heart < 0)
        {
            gameOn = false;
            StopAllCoroutines();
            Enemies[] enemies = FindObjectsOfType<Enemies>();
            player.SetActive(false);
            Instantiate(ParticleSystem, Vector3.zero, ParticleSystem.transform.rotation);
            foreach (var enemy in enemies)
            {
                Destroy(enemy.gameObject);
            }
            ingameScore.SetActive(false);
            finalScore.SetActive(true);
            score.SetText(points.ToString());
            
        }
    }

    public void StartGame()
    {
        gameOn = true;
        startGameUI.SetActive(false);
        player.SetActive(true);
        ingameScore.SetActive(true);
    }

    public void Restart()
    {
        gameOn = true;
        RefillHearts();
        points = 0;
        heart = 2;
        startGameUI.SetActive(false);
        player.SetActive(true);
        finalScore.SetActive(false);
        ingameScore.SetActive(true);
    }

    void RefillHearts()
    {
        foreach (var iamge in hearts)
        {
            iamge.SetActive(true);
        }
    }
}
