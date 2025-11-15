using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class JogadorControladorDeAtaques : MonoBehaviour
{
    JogadorControladorMovimento JoggMovimento;

    float timerCombo; //Combo
    int qualAtaque;

    bool atacando;//Usado para não chamar um ataque quando o outro está acontecendo

    bool knockback;//feita para verificar a cada atque se o jogador atingiu alguma coisa que provoca knockback

    [SerializeField] float dano; //Dano base do jogador, utilizado nos calculos

    public SpriteRenderer hitboxVisual;

    Vector3 offset; //Offset do detector de ataques
    Vector3 tamanhoDoAtaque; //tamanho da hitbox dos ataques
    void Start()
    {
       
        dano = 5;

        JoggMovimento = transform.parent.GetComponentInChildren<JogadorControladorMovimento>(); //Referencia o componente em outro objeto

        InputManager.Instancia.Input_JogadorAtaqueBasico.performed += InputAtaquePressionado;

        tamanhoDoAtaque = new Vector3(0.6f, 0.3f, 0);

        

        hitboxVisual.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (timerCombo > 0)
        {
            timerCombo-=Time.deltaTime;
        }
        else
        {
            qualAtaque = 0;
        }
    }
    void InputAtaquePressionado(InputAction.CallbackContext context) //Faz com que o pulo comece
    {
        if (!atacando)
        {
            if (qualAtaque > 2)
            {
                qualAtaque=0;
            }
            TentarAtaque(qualAtaque);
            qualAtaque++;
        }
    }
    void TentarAtaque(int QualAtaque)
    {
       switch (QualAtaque)
       {
            case 0: StartCoroutine(Ataque()); break; 
            case 1: StartCoroutine(Ataque()); break;
            case 2: StartCoroutine(Ataque()); break;
       }
    }
    IEnumerator Ataque()
    {

        if (JoggMovimento.MoveInput.y == 0)
        {
            offset = new Vector3(JoggMovimento.DireçaoDoJogador * 0.3f, 0, 0);
        }
        else
        {
            offset = new Vector3(0, JoggMovimento.MoveInput.y * 0.3f, 0);
        }

        float incremento;
        Vector3 tamanhoFinal;
        if (JoggMovimento.MoveInput.y != 0)
            tamanhoFinal = new Vector2(tamanhoDoAtaque.y, tamanhoDoAtaque.x); //Se o jogador está pressionando os inputs de movimentação para cima ou para baixo modifica o tamanhao para ser vertical
        else
            tamanhoFinal = new Vector2(tamanhoDoAtaque.x, tamanhoDoAtaque.y);

        hitboxVisual.size = tamanhoFinal;
        atacando = true;
        timerCombo = 0.5f;
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position + offset, tamanhoFinal, 0);

        hitboxVisual.color = new Color(1, 1, 1, 1);
        hitboxVisual.transform.position = this.transform.position + offset;
        foreach (Collider2D hit in hits)
        {
            if(hit.TryGetComponent(out Interfaces.IDanificavel valido))
            {
                valido.receberDano(dano);
                knockback = true;
            }
            if (hit.gameObject.layer==3)
            {
                knockback=true;
            }
        }
        if (knockback)
        {
            JoggMovimento.JogadorEstado = JogadorControladorMovimento.JogadorEstados.knockback; //Altera o modo para evitar os inputs de movimento
            if (JoggMovimento.MoveInput.y==0)
            {
                JoggMovimento.Rb.linearVelocity = new Vector2(0, JoggMovimento.Rb.linearVelocity.y); //Para o jogador
                incremento = 5;
            }
            else 
            {
                JoggMovimento.Rb.linearVelocity = new Vector2( JoggMovimento.Rb.linearVelocity.x,0); //Para o jogador
                if (JoggMovimento.MoveInput.y == -1)
                {
                    incremento = 20;
                }
                else
                {
                    incremento = 5;
                }                   
            }           
            JoggMovimento.Rb.AddForce(-offset*incremento, ForceMode2D.Impulse);  //Se atingiu alguma coisa aplica knockback
        }
        knockback = false;      
        yield return new WaitForSeconds(0.2f);
        hitboxVisual.color = new Color(1, 1, 1, 0);
        JoggMovimento.JogadorEstado = JogadorControladorMovimento.JogadorEstados.normal;
        atacando = false;
        
    }
}
