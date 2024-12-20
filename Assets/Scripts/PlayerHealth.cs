using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float life = 100;
    public Image healthBar;


    void Update()
    {
        life = Mathf.Clamp(life, 0, 100);

        healthBar.fillAmount = life / 100;

    }

    void EndGame()
    {
        if (life < 0)
        {
            FindObjectOfType<PauseMenu>().GameOver();
        }
    }
}
