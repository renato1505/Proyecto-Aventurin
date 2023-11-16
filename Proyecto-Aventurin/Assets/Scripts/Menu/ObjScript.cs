using UnityEngine;

public class SpeedChangeTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))  
        {
            Destroy(gameObject);  
        }
    }
}
