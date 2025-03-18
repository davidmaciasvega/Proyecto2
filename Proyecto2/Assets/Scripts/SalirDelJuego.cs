using UnityEngine;

public class SalirDelJuego : MonoBehaviour
{
    // Método para cerrar la aplicación
    public void Salir()
    {
        Debug.Log("El juego se está cerrando...");

        // Cierra la aplicación si es un build (NO funciona en el editor)
        Application.Quit();
    }
}
