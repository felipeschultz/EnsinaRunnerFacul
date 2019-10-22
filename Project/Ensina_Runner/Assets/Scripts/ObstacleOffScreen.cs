using UnityEngine;

public class ObstacleOffScreen : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Collector")
        {
            gameObject.SetActive(false);
        }
    }
}
