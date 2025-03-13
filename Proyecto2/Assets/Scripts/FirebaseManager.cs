using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Firestore;
using Firebase.Extensions;

public class FirebaseManager : MonoBehaviour
{
    FirebaseFirestore db;
    public static FirebaseManager instancia; // Para hacer el objeto persistente

   
    void Awake()
    {
        // Asegurar que solo haya una instancia de FirebaseManager y que no se destruya entre niveles
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
       else
    {
        Debug.LogWarning("🔥 Ya existe un FirebaseManager, destruyendo duplicado...");
        Destroy(gameObject);
        return;
    }

    db = FirebaseFirestore.DefaultInstance;
}

    // 🔥 Método para GUARDAR el progreso (agregamos un callback opcional)
    public void GuardarProgreso(int monedas, int nivel, System.Action callback = null)
    {
        Dictionary<string, object> datos = new Dictionary<string, object>
        {
            { "monedas", monedas }, 
            { "nivel", nivel }
        };

        db.Collection("jugadores").Document("player1").SetAsync(datos).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("✅ Datos guardados en Firebase correctamente.");
                callback?.Invoke(); // Llamar callback si existe
            }
            else
            {
                Debug.LogError("❌ Error al guardar en Firebase: " + task.Exception);
            }
        });
    }

    // 🔥 Método para CARGAR el progreso guardado
    public void CargarProgreso(System.Action<int, int> callback)
    {
        db.Collection("jugadores").Document("player1").GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                DocumentSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    int monedas = snapshot.GetValue<int>("monedas");
                    int nivel = snapshot.GetValue<int>("nivel");
                    callback(monedas, nivel); // Pasamos los datos al Score.cs
                }
                else
                {
                    Debug.Log("No hay datos previos guardados.");
                    callback(0, 1); // Si no hay datos, empezamos desde 0 monedas y nivel 1
                }
            }
            else
            {
                Debug.LogError("❌ Error al cargar datos de Firebase: " + task.Exception);
            }
        });
    }
    public void ResetearProgreso()
{
    Dictionary<string, object> datos = new Dictionary<string, object>
    {
        { "monedas", 0 }, 
        { "nivel", 1 }
    };

    db.Collection("jugadores").Document("player1").SetAsync(datos).ContinueWithOnMainThread(task =>
    {
        if (task.IsCompleted)
        {
            Debug.Log("🔄 Progreso reseteado a 0 monedas y nivel 1.");
        }
        else
        {
            Debug.LogError("❌ Error al resetear progreso en Firebase: " + task.Exception);
        }
    });
}
}
