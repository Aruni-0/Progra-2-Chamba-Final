using UnityEngine;
using UnityEngine.AI;

public class EnemigoAvanzado : MonoBehaviour, IDañables
{
    #region Variables
    public int Vida { get; set; }
    public LayerMask golpeadoPor { get; set; }
    public MaquinaEstados maquinita;
    public EstadoIdle estadoIdle;
    public EstadoPerseguir estadoPerseguir;
    public EstadoAtaque estadoAtaque;

    public NavMeshAgent agente;
    public float rangoMovimientoRandom = 5f;
    #region persecucion
    [Header("Variables Persecución")]
    public float radioDeteccion;
    public LayerMask capaJugador;
    public ControlJugador jugador;
    #endregion persecucion

    public float rangoAtaque;



    #endregion Variables

    private void Awake()
    {
        maquinita = new MaquinaEstados();
        estadoIdle = new EstadoIdle(this, maquinita);
        estadoAtaque = new EstadoAtaque(this, maquinita);
        estadoPerseguir = new EstadoPerseguir(this, maquinita);

        jugador = FindAnyObjectByType<ControlJugador>();
        maquinita.Inicializar(estadoIdle);
    }

    private void Update()
    {
        maquinita.estadoActual.FrameUpdate();

        if (maquinita.estadoActual != estadoPerseguir && Physics.CheckSphere(transform.position, radioDeteccion, capaJugador))
        {
            maquinita.CambiarEstado(estadoPerseguir);
        }
        else if (maquinita.estadoActual == estadoPerseguir && !Physics.CheckSphere(transform.position, radioDeteccion, capaJugador))
        {
            maquinita.CambiarEstado(estadoIdle);
        }

        if(maquinita.estadoActual != estadoAtaque && Physics.CheckSphere(transform.position, rangoAtaque, capaJugador))
        {
            maquinita.CambiarEstado(estadoAtaque);
        }
    }

    public void RecibirDaño(int dañitos)
    {
        if (Vida <= 0)
        {
            Palmarla();
        }
    }

    public void Palmarla()
    {

    }
}
