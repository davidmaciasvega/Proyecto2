using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonNivel1 : MonoBehaviour
{
    public void IrANivel1()
    {
        Debug.Log("Botón presionado, cargando Nivel 1...");
        SceneManager.LoadScene("Nivel 1");
    }
}
