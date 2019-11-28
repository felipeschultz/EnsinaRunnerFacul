using UnityEngine;

public class DestroyIconOffScreen : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Collector")
        {
            Destroy(gameObject);
        }
    }
}