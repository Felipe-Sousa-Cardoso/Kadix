using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class JogadorControladorDeAtaques : MonoBehaviour
{
    [SerializeField]  JogadorControladorMovimento JoggMovimento;
    [SerializeField] float timerAtaque;
    [SerializeField] float timerCombo;

    [SerializeField] int qualAtaque;
    [SerializeField] bool podeAtacar;
    [SerializeField] bool atacando;

    Vector3 offset; //Offset do detector de ataques
    Vector3 tamanho; //tamanho da hitbox dos ataques
    void Start()
    {
        podeAtacar = true;
        JoggMovimento = transform.parent.GetComponentInChildren<JogadorControladorMovimento>(); //Referencia o componente em outro objeto
        InputManager.Instancia.Input_JogadorAtaqueBasico.performed += InputAtaquePressionado;
        tamanho = new Vector3(0.6f, 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector3(JoggMovimento.DireçaoDoJogador*0.3f,0,0);

        if (timerAtaque> 0) //Usado para verificar a lógica dos ataques
        {
            timerAtaque -=Time.deltaTime;
        }
        else
        {
            Gizmos.color = Color.red;
        }

        if (timerCombo> 0)
        {
            timerCombo -=Time.deltaTime;
        }
        else
        {
            qualAtaque = 0;
        }
    }
    void InputAtaquePressionado(InputAction.CallbackContext context) //Faz com que o pulo comece
    {
        if (podeAtacar&&timerAtaque<=0)
        {
            TentarAtaque(qualAtaque);
        }
    }

    void TentarAtaque(int QualAtaque)
    {
       switch (QualAtaque)
       {
            case 0: print("ataque1"); Ataque(); break; 
            case 1: print("ataque2"); Ataque(); break;
            case 2: print("ataque3"); Ataque(); break;
       }
    }

    IEnumerator Ataque()
    {
        timerAtaque = 0.2f;
        atacando = true;
    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position+offset, tamanho);
    }
}
