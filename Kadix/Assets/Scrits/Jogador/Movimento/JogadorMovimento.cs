using UnityEngine;

public class JogadorMovimento : MonoBehaviour
{
    #region Componentes da unity
    private Rigidbody2D rb;
    public Rigidbody2D Rb { get => rb; set => rb = value; }
    #endregion
    #region Variáveis

    [SerializeField] private Vector2 moveInput; //Input de movimento horizontal
    public Vector2 MoveInput { get => moveInput; set => moveInput = value; }

    private int velocidade = 5; //Velocidade de movimento do jogador
    public int Velocidade { get => velocidade; set => velocidade = value; }

    private float alturaDoPulo = 0.3f; //Altura máxima que um único pulo pode chegar, é aplicado como tempo
    public float AlturaDoPulo { get => alturaDoPulo; set => alturaDoPulo = value; }
  
    private bool noChao; //Verifica se o jogador está sobre um terreno pulável
    public bool NoChao { get => noChao; set => noChao = value; }

    private bool encostandoNaParede; //Verifica se tem uma parede muito proxima ao jogador e ele está se movendo em direção a ela
    public bool EncostandoNaParede { get => encostandoNaParede; set => encostandoNaParede = value; }

    [SerializeField] private int direçaoDoJogador; //Guarda o ultimo input de movimento dado, controlado pelas animações
    public int DireçaoDoJogador { get => direçaoDoJogador; set => direçaoDoJogador = value; }
    public LayerMask layerChao;
    #endregion
    #region maquina de estado
    public enum JogadorEstados
    {
        normal,
        paradoNoAr,
        semInputX
    }
    JogadorEstados jogadorEstado;
    public JogadorEstados JogadorEstado { get => jogadorEstado; set => jogadorEstado = value; }
  
    #endregion
    Vector3 offset = new Vector3 (0,-0.2f,0); //offset para a correta verificação do terreno

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = InputManager.Instancia.Input_jogadorMovimentoBasico.ReadValue<Vector2>();
        noChao = Physics2D.OverlapBox(transform.position+offset, new Vector2(0.35f,0.1f),0f, layerChao); //Verifica o chão corretamente
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = noChao ? Color.green : Color.red;
        Gizmos.DrawWireCube(transform.position + offset, new Vector2(0.35f, 0.1f));
    }
}
