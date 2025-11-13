using UnityEngine;

public class Interfaces : MonoBehaviour
{
    public interface IPulo
    {
        bool PodePular();
        void ExecutarPulo();
        void CancelarPulo();
    }
    public interface IDanificavel
    {
        void receberDano(float dano);  
    }

}
