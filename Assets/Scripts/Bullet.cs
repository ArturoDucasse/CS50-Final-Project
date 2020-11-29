using UnityEngine;

    public class Bullet : MonoBehaviour
    {
        public float speed = 5;
        private void Update()
        {
        //Makes the bullet moves straight forward
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            Destroy(gameObject,20);
        }
    }
