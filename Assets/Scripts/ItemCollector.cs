using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    public ScoreManager scoreManager; 
    SettingsMenu sceneManager;
    public AudioSource audioPlayer;
        

    private void Awake() 
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //audioPlayer.Play();
        if (other.gameObject.CompareTag("Item"))
        {
            
            
            scoreManager.AddPoints(10);
            
            Destroy(other.gameObject);
        }
    }
}