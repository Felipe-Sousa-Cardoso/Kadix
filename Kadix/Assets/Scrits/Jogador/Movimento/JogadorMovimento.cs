using UnityEngine;

public class JogadorMovimento : MonoBehaviour
{
    #region Componentes da unity
    private Rigidbody2D rb;
    public Rigidbody2D Rb { get => rb; set => rb = value; }

    #endregion
    #region Variáveis

    private Vector2 moveInput; //Input de movimento horizontal
    public Vector2 MoveInput { get => moveInput; set => moveInput = value; }

    private int velocidade = 5; //Velocidade de movimento do jogador
    public int Velocidade { get => velocidade; set => velocidade = value; }

    private bool puloInput; //Altura máxima que um único pulo pode chegar, é aplicado como tempo
    public bool PuloInput { get => puloInput; set => puloInput = value; }

    private float alturaDoPulo = 1.0f; //Altura máxima que um único pulo pode chegar, é aplicado como tempo
    public float AlturaDoPulo { get => alturaDoPulo; set => alturaDoPulo = value; }

    #endregion


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput = InputManager.GetInput_jogadorMovimento();
        puloInput = InputManager.GetInput_jogadorMovimentoPulo();
    }
}
