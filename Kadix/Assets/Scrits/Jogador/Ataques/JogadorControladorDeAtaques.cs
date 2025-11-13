using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class JogadorControladorDeAtaques : MonoBehaviour
{
    [SerializeField]  JogadorControladorMovimento JoggMovimento;

    [SerializeField] float timerCombo; //Combo
    [SerializeField] int qualAtaque;

    [SerializeField] bool atacando;

    bool knockback;

    Collider2D[] hits;

    [SerializeField] float dano; //Dano base do jogador, utilizado nos calculos

    Vector3 offset; //Offset do detector de ataques
    Vector3 tamanhoDoAtaque; //tamanho da hitbox dos ataques
    void Start()
    {
        dano = 5;

        JoggMovimento = transform.parent.GetComponentInChildren<JogadorControladorMovimento>(); //Referencia o componente em outro objeto

        InputManager.Instancia.Input_JogadorAtaqueBasico.performed += InputAtaquePressionado;

        tamanhoDoAtaque = new Vector3(0.6f, 0.3f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector3(JoggMovimento.DireçaoDoJogador*0.3f,0,0);

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
        atacando = true;
        timerCombo = 0.5f;
        hits = Physics2D.OverlapBoxAll(transform.position + offset, tamanhoDoAtaque, 0f);
        foreach (Collider2D hit in hits)
        {
            if(hit.TryGetComponent<Interfaces.IDanificavel>(out Interfaces.IDanificavel valido))
            {
                valido.receberDano(dano);
                knockback = true;
            }
            if (hit.gameObject.layer == 3)
            {
                knockback=true;
            }
        }
        if (knockback)
        {
            JoggMovimento.JogadorEstado = JogadorControladorMovimento.JogadorEstados.knockback;
            JoggMovimento.Rb.linearVelocity = new Vector2( 0, JoggMovimento.Rb.linearVelocityY);
            JoggMovimento.Rb.AddForce(new Vector2(-JoggMovimento.DireçaoDoJogador,0), ForceMode2D.Impulse);  //Se atingiu alguma coisa aplica knockback
        }
        knockback = false;
        yield return new WaitForSeconds(0.2f);
        JoggMovimento.JogadorEstado = JogadorControladorMovimento.JogadorEstados.normal;
        atacando = false;


    }

    private void OnDrawGizmos()
    {      
        if (atacando)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color= Color.red;        
        }
        Gizmos.DrawCube(transform.position + offset, tamanhoDoAtaque);
    }
}
