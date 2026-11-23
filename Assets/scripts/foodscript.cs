using UnityEngine;

public class FoodItem : MonoBehaviour
{
    private FoodSpawner spawner;
    
    void Start()
    {
        // Find the spawner
        spawner = FindObjectOfType<FoodSpawner>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Food collected!");
            
            // Notify spawner to create new food
            if (spawner != null)
            {
                spawner.OnFoodCollected();
            }
            
            // Destroy this food
            Destroy(gameObject);
        }
    }
}