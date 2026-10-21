using UnityEngine;

public class Trampita : MonoBehaviour, IInteractuable
{
    [SerializeField] private ParticleSystem particulas;

    public void Interactuar()
    {
        particulas.Play();
    }
}
