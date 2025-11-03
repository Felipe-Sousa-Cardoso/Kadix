using UnityEngine;

public class JogadorPulo : MonoBehaviour
{
    JogadorMovimento JoggMovimento;

    public bool isJump; //Verifica se o comando de pular foi dado, usado para altura do pulo e verificações
    public float tempoPulo;
    void Start()
    {
        JoggMovimento = GetComponent<JogadorMovimento>(); //recebe o componente que contem as variáveis do Jogador
    }

    private void Update()
    {
        if (JoggMovimento.MoveInput.y == 1 & JoggMovimento.NoChao & !isJump) //Se o input está pressiondo e o jogador está no chão o jogador começa a pular
        {
            isJump = true;
        }
        if (JoggMovimento.MoveInput.y != 1 & isJump || tempoPulo >= JoggMovimento.AlturaDoPulo) //Se o input não continua pressionado ou tempo de pulo acabou
        {
            isJump = false; //para de pular
            tempoPulo = 0; //Reseta para um novo pulo
            JoggMovimento.Rb.linearVelocity = new Vector2(JoggMovimento.Rb.linearVelocity.x, JoggMovimento.Rb.linearVelocity.y * 0.2f); //freia bruscamente o jogador Reseta para um novo pulo
        }
        if (isJump & tempoPulo < JoggMovimento.AlturaDoPulo) //Se o jogador ainda está pulando e ainda não atingiu a altura máxima
        {
            tempoPulo += Time.deltaTime;
        }
       
      
    }
    void FixedUpdate()
    {
        if (isJump)
        {
            JoggMovimento.Rb.linearVelocity = new Vector2 (JoggMovimento.Rb.linearVelocity.x,5);
        }
        
    }
}
