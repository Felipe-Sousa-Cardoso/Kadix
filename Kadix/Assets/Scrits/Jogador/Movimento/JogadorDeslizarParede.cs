using UnityEngine;

public class JogadorDeslizarParede : MonoBehaviour
{
    JogadorControladorMovimento JoggMovimento;
    bool direçãonova;
    void Start()
    {
        JoggMovimento = GetComponent<JogadorControladorMovimento>(); //recebe o componente que contem as variáveis 
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * JoggMovimento.DireçaoDoJogador, 0.25f, JoggMovimento.layerChao);
        //verifica se o jogador está proximo da parede e se movimentando em direção a ela
        Color cor = hit ? Color.green : Color.red;
        Debug.DrawRay(transform.position, Vector2.right * JoggMovimento.MoveInput.x*0.25f, cor);

        JoggMovimento.EncostandoNaParede = hit;

    }

    private void FixedUpdate()
    {
        if (JoggMovimento.EncostandoNaParede && !JoggMovimento.NoChao&& JoggMovimento.JogadorEstado == JogadorControladorMovimento.JogadorEstados.normal)
        { 
          JoggMovimento.Rb.linearVelocity = new Vector2(0, -1f);         
        }
    }
}
