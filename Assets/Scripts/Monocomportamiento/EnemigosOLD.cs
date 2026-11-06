using UnityEngine;
using UnityEngine.AI;

public class EnemigosOLD : MonoBehaviour, IDañables
{
    public int vida;
    public EnemigosSO datos;
    private NavMeshAgent agente;
    public Transform objetivo;

    private void Start()
    {
        agente = transform.GetComponent<NavMeshAgent>();
        agente.speed = datos.velocidad;
        vida = datos.vida;
    }

    private void Update()
    {
        if (objetivo != null)
        {
            agente.destination = objetivo.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            Destroy(collision.gameObject);
        }
    }

    public void RecibirDaño(int dañitos)
    {
        vida = vida - dañitos;

        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
