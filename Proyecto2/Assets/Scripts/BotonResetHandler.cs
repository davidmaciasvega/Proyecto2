using UnityEngine;

public class BotonResetHandler : MonoBehaviour
{
    // Llamado cuando el botón de reset es presionado.
    public void OnResetButtonClicked()
    {
        // Asegúrate de que la instancia de FirebaseManager esté disponible
        if (FirebaseManager.instancia != null)
        {
            // Llama al método de Resetear progreso de FirebaseManager
            FirebaseManager.instancia.ResetearProgreso();
            Debug.Log("✅ Progreso reseteado a través de FirebaseManager.");
        }
        else
        {
            Debug.LogError("❌ FirebaseManager no está disponible.");
        }
    }
}
