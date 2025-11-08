using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Interfaces;

public class JogadorControladorDePulo : MonoBehaviour
{
    protected JogadorMovimento JoggMovimento;
    [SerializeField] PuloWrapper[] pulos;
    [SerializeField] PuloWrapper puloAtual;
    public struct PuloWrapper
    {
        public IPulo Interface;
        public MonoBehaviour Componente;
    }
    void Start()
    {
        JoggMovimento = GetComponent<JogadorMovimento>();
        InputManager.Instancia.Input_JogadorMovimentoPulo.started += InputPuloPressionado; //Inscreve nos input a ação de começar e finalizar o pulo
        InputManager.Instancia.Input_JogadorMovimentoPulo.canceled += InputPuloConcluido;

        var behaviours = GetComponents<MonoBehaviour>();
        var lista = new List<PuloWrapper>();

        foreach (var b in behaviours)
        {
            if (b is IPulo p)
                lista.Add(new PuloWrapper { Interface = p, Componente = b });
        }
        pulos = lista.ToArray();

        foreach (var pulo in pulos)
            Debug.Log($"Componente de pulo encontrado: {pulo.Componente.GetType().Name} está {pulo.Componente.enabled}" );
    }
    void InputPuloPressionado(InputAction.CallbackContext context) //Faz com que o pulo comece
    {
        TentarPular();
    }
    void InputPuloConcluido(InputAction.CallbackContext context) //Se ele está pulando encerra o pulo
    {
        puloAtual.Interface.CancelarPulo();
    }

    public void TentarPular()
    {
        foreach (var pulo in pulos)
        {
            
            if (pulo.Componente.enabled == false)
            {
                continue;
            } //Se o jogador não desbloqueou o dash
            if (pulo.Interface.PodePular())
            {
                puloAtual = pulo;
                if (JoggMovimento.JogadorEstado != JogadorMovimento.JogadorEstados.normal)
                {
                    JoggMovimento.JogadorEstado = JogadorMovimento.JogadorEstados.normal;
                }
                pulo.Interface.ExecutarPulo();
                return;
            }// executa só o primeiro que for possível
        }
    }
}
