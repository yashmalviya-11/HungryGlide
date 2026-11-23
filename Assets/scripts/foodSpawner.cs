using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public Camera gameCamera;
    public float padding = 50f;
    
    private bool isSpawning = false;

    void Start()
    {
        if (gameCamera == null)
            gameCamera = Camera.main;
            
        // Spawn the first food
        SpawnFood();
    }
    
    void SpawnFood()
    {
        if (foodPrefab == null || isSpawning) return;
        
        isSpawning = true;
        
        // Get random screen position
        Vector2 screenPosition = new Vector2(
            Random.Range(padding, Screen.width - padding),
            Random.Range(padding, Screen.height - padding)
        );
        
        // Convert to world position
        Vector3 worldPosition = gameCamera.ScreenToWorldPoint(screenPosition);
        worldPosition.z = 0f;
        
        // Create food
        Instantiate(foodPrefab, worldPosition, Quaternion.identity);
        
        Debug.Log("New food spawned!");
        isSpawning = false;
    }
    
    // This method is called when food is collected
    public void OnFoodCollected()
    {
        Debug.Log("Food collected! Spawning new one...");
        SpawnFood();
    }
}