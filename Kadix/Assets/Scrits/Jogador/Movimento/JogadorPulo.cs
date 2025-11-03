using UnityEngine;
using UnityEngine.InputSystem;

public class JogadorPulo : MonoBehaviour
{
    JogadorMovimento JoggMovimento;

    public bool isJump; //Verifica se o comando de pular foi dado, usado para altura do pulo e verificações
    public float tempoPulo;
    void Start()
    {
        JoggMovimento = GetComponent<JogadorMovimento>(); //recebe o componente que contem as variáveis do Jogador
        InputManager.Instancia.Input_JogadorMovimentoPulo.started += InputPuloPressionado;
        InputManager.Instancia.Input_JogadorMovimentoPulo.canceled += InputPuloConcluido;
    }

    

    void InputPuloPressionado(InputAction.CallbackContext context)
    {
        if (JoggMovimento.NoChao & !isJump) //Se o input está pressiondo e o jogador está no chão o jogador começa a pular
        {
            isJump = true;
        }
    }
    void InputPuloConcluido(InputAction.CallbackContext context)
    {
        puloConcluido();
    }

    private void Update()
    {            
        if (isJump & tempoPulo < JoggMovimento.AlturaDoPulo) //Se o jogador ainda está pulando e ainda não atingiu a altura máxima
        {
            tempoPulo += Time.deltaTime;
        }
        if (isJump & tempoPulo>= JoggMovimento.AlturaDoPulo)
        {
            puloConcluido();
        }
    }
    void FixedUpdate()
    {
        if (isJump)
        {
            JoggMovimento.Rb.linearVelocity = new Vector2 (JoggMovimento.Rb.linearVelocity.x,5);
        }    
    }

    void puloConcluido()
    {
        isJump = false; //para de pular
        tempoPulo = 0; //Reseta para um novo pulo
        JoggMovimento.Rb.linearVelocity = new Vector2(JoggMovimento.Rb.linearVelocity.x, JoggMovimento.Rb.linearVelocity.y * 0.2f); //freia bruscamente o jogador Reseta para um novo pulo
    }
}
