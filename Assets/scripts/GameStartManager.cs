using UnityEngine;
using UnityEngine.UI;

public class GameStartManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject tapToStartPanel;
    public Button tapButton;
    
    [Header("Game Elements")]
    public GameObject gameElements;
    
    [Header("Player Reference")]
    public MonoBehaviour playerController; // Drag your player script here
    public Rigidbody2D playerRigidbody; // Optional: if using physics

    void Start()
    {
        // Ensure tap panel is visible and game is paused at start
        ShowTapToStart();
        
        // Disable player control immediately
        if (playerController != null)
            playerController.enabled = false;
            
        // Stop player physics if using Rigidbody
        if (playerRigidbody != null)
            playerRigidbody.simulated = false;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && tapToStartPanel.activeInHierarchy)
        {
            StartGame();
        }
    }
    
    public void ShowTapToStart()
    {
        // Show tap to start panel
        if (tapToStartPanel != null)
            tapToStartPanel.SetActive(true);
        
        // Hide game elements (optional)
        if (gameElements != null)
            gameElements.SetActive(false);
        
        // Pause game logic
        Time.timeScale = 0f;
        
        // Disable player control
        if (playerController != null)
            playerController.enabled = false;
            
        // Stop physics
        if (playerRigidbody != null)
            playerRigidbody.simulated = false;
        
        // Add button listener
        if (tapButton != null)
        {
            tapButton.onClick.RemoveAllListeners();
            tapButton.onClick.AddListener(StartGame);
        }
    }
    
    public void StartGame()
    {
        // Hide tap to start panel
        if (tapToStartPanel != null)
            tapToStartPanel.SetActive(false);
        
        // Show game elements
        if (gameElements != null)
            gameElements.SetActive(true);
        
        // Resume game logic
        Time.timeScale = 1f;
        
        // Enable player control
        if (playerController != null)
            playerController.enabled = true;
            
        // Start physics
        if (playerRigidbody != null)
            playerRigidbody.simulated = true;
        
        Debug.Log("Game Started!");
    }
}