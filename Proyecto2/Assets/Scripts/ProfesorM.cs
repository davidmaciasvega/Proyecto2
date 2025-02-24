using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class ProfesorM : MonoBehaviour
{
    private Rigidbody2D rigidbody2D; // Cambio en el nombre de la variable para seguir la convención
    private float horizontal;

    void Start()
    {
        // Corrección del nombre del componente
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        // Aquí puedes añadir la lógica para manejar las entradas
    }

    private void FixedUpdate()
    {
        // Corrección en la definición de FixedUpdate
        rigidbody2D.linearVelocity = new Vector2(horizontal, 0);
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
