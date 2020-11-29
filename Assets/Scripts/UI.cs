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
    //Making sure to set the text
        pointsText.SetText("Points: " + points);
    }

    public void HeartsLeft()
    {
    //Disabling the hearts depending of the index(heart)
        hearts[heart].SetActive(false);
        heart--;
        //If heart is less than 0 means that the game has ended.
        if (heart < 0)
        {
            gameOn = false;
            StopAllCoroutines();
            Enemies[] enemies = FindObjectsOfType<Enemies>();
            player.SetActive(false);
            Instantiate(ParticleSystem, Vector3.zero, ParticleSystem.transform.rotation);
            //Destroy any enemy left in the screen 
            foreach (var enemy in enemies)
            {
                Destroy(enemy.gameObject);
            }
            //Activating/deactivating the corresponding panels
            ingameScore.SetActive(false);
            finalScore.SetActive(true);
            //Setting the end value
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
    //Re activating the sprites
    void RefillHearts()
    {
        foreach (var iamge in hearts)
        {
            iamge.SetActive(true);
        }
    }
}
