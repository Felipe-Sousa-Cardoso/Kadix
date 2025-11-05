using UnityEngine;

public class JogadorDeslizarParede : MonoBehaviour
{
    JogadorMovimento JoggMovimento;

    public bool encostandoNaParede;
    void Start()
    {
        JoggMovimento = GetComponent<JogadorMovimento>(); //recebe o componente que contem as variáveis 
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * JoggMovimento.MoveInput.x, 0.25f, JoggMovimento.layerChao); 
        //verifica se o jogador está proximo da parede e se movimentando em direção a ela
        Color cor = hit ? Color.green : Color.red;
        encostandoNaParede = hit ? true : false;
        Debug.DrawRay(transform.position, Vector2.right * JoggMovimento.MoveInput.x*0.25f, cor);
    }

    private void FixedUpdate()
    {
        if (encostandoNaParede && !JoggMovimento.NoChao)
        {
            JoggMovimento.Rb.linearVelocity = new Vector2(0, -1f);
        }
    }
}
