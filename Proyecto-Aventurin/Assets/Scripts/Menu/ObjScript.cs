using UnityEngine;

public class SpeedChangeTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))  // Asume que el tag del personaje es "Player"
        {
            Destroy(gameObject);  // Destruye el objeto trigger
        }
    }
}
