using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI NivelText; 

    void Start()
    {
        score = 0;
        Debug.Log("Score está activo");
        NivelText.text = "Nivel: " + (SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Moneda")
        {
            score++;
            Debug.Log("¡Moneda recogida! Cantidad: " + score);

            scoreText.text = "Score: " + score;
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        NivelText.text = "Nivel: " + (SceneManager.GetActiveScene().buildIndex + 1);
    }
}

