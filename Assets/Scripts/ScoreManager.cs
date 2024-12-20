using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Puntos iniciales
    public Text scoreText; // Referencia al componente de texto en el Canvas

    void Start()
    {
        // Inicializa el puntaje en el texto
        UpdateScoreText();
    }

    public void AddPoints(int points)
    {
        // Suma puntos al total
        score += points;

        // Actualiza el texto del puntaje
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        // Cambia el texto del UI
        scoreText.text = "Score:" + score;
    }
}