using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;

    // Defina os limites do campo para o jogador de baixo (ajuste os valores conforme sua cena)
    public float minY = -4.5f;
    public float maxY = -0.5f; // Meio de campo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() // Use FixedUpdate para f�sica
    {
        //[cite_start]// 1. Pega a posi��o do mouse no mundo [cite: 37]
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //[cite_start]// 2. Calcula a dire��o entre o player e o mouse [cite: 38]
        Vector2 direction = (Vector2)mousePos - rb.position;

        //[cite_start]// 3. Move usando Velocidade (Isso garante o impacto f�sico) 
        // Usamos Lerp ou clamp magnitude para evitar "tremedeira" quando o mouse est� muito perto
        rb.linearVelocity = direction * speed;

        //[cite_start]// 4. Limitar a posi��o (N�o invadir campo advers�rio) 
        Vector2 clampedPosition = rb.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        rb.position = clampedPosition;
    }
}