using UnityEngine;

public class AIController : MonoBehaviour
{

    public Transform puck; // Arraste a bolinha aqui no Inspector
    public float speed = 5f; // Velocidade da IA (não deixe muito rápido para ser vencível)

    // Limites do campo superior (Y positivo)
    public float minY = 0.5f; // Linha do meio
    public float maxY = 4.5f; // Fundo do campo

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (puck == null) return;

        // A IA quer chegar na posição X da bolinha, mas mantém seu próprio Y ideal (defensivo)
        // ou avança um pouco se a bolinha estiver perto.
        float targetX = puck.position.x;

        // Simples comportamento: Move-se apenas no eixo X para bloquear
        // Para ficar mais interessante, a IA pode tentar acompanhar o Y da bola até certo ponto
        float targetY = Mathf.Clamp(puck.position.y, minY, maxY);

        Vector2 targetPosition = new Vector2(targetX, targetY);

        // Move suavemente em direção ao alvo
        Vector2 newPos = Vector2.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime);

        // Garante que não saia dos limites
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);

        rb.MovePosition(newPos);
    }
}
