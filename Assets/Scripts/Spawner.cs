using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;
    public float timer = 5;
    public float coolDown = 3;
    private int up = 30;

    private void Update()
    {
    //Making the spawn rate random with this variable
        coolDown = Random.Range(timer, 10f);
        if (UI.gameOn)
        {
            if (Time.time > timer)
            {
                Instantiate(obstacle, transform.position, quaternion.identity);
                timer = Time.time + coolDown;
            }

            if (Time.time > up)
            {
                timer--;
                up += 30;
            }
        }
    }
}
