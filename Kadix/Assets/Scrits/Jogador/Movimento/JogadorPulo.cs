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
        if (JoggMovimento.MoveInput.y == 0 & isJump) //Verifica se o botão de pulo foi solto mas ainda não foi negado a variável isJump, fazendo com que essa linha só execute uma vez
        {
            JoggMovimento.Rb.linearVelocity = new Vector2(JoggMovimento.Rb.linearVelocity.x, JoggMovimento.Rb.linearVelocityY*0.1f); //Desacelera bruscamente o Jogador qunado o botão é solto
        }
        if (JoggMovimento.MoveInput.y==1 & tempoPulo < JoggMovimento.AlturaDoPulo) //Se o input está pressiondo e o tempo de pulo ainda não acabou continua a subida
        {
            isJump = true;
            tempoPulo += Time.deltaTime;
        }
        else
        {
            isJump = false;
            tempoPulo = 0;         
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
