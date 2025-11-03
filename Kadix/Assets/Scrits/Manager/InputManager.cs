using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instancia;
    void Awake() //Verificação de unicidade
    {
        if (Instancia == null)
        {
            Instancia = this;
        }
        else
        {
            Destroy(this);
        }

    }
    
    InputAction InputA_jogadorMovimento;   //movimento basico para os lados

    private void Start()
    {
        InputA_jogadorMovimento = InputSystem.actions.FindAction("Movimento");
    }
    public static Vector2 GetInput_jogadorMovimento()
    {
        return Instancia.InputA_jogadorMovimento.ReadValue<Vector2>();
    }
    



}
