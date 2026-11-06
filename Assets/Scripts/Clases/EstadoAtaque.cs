using UnityEngine;

public class EstadoAtaque : EstadoEnemigo
{
    private float tiempoEntreAtaques = 2f;
    private float temporizadorAtaque;

    private float tiempoAntesDeSalir;
    private float tiempoSalida;

    public EstadoAtaque(EnemigoAvanzado _enemigoAvanzado, MaquinaEstados _maquina) : base(_enemigoAvanzado, _maquina)
    {

    }

    public override void EntrarEstado()
    {
        base.EntrarEstado();
    }

    public override void SalirEstado()
    {
        base.SalirEstado();
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        enemigoAvanzado.agente.SetDestination(enemigoAvanzado.transform.position);

        if (temporizadorAtaque > tiempoEntreAtaques)
        {
            temporizadorAtaque = 0;
            Ray rayo = new Ray(enemigoAvanzado.transform.position + Vector3.up, enemigoAvanzado.transform.forward);
            Debug.DrawRay(enemigoAvanzado.transform.position + Vector3.up, enemigoAvanzado.transform.forward * 5, Color.red, 3f);

            if (Physics.Raycast(rayo, 5f))
            {
                Debug.Log("Le pegaste al jugador");
            }

            temporizadorAtaque += Time.deltaTime;

            if (Vector2.Distance(enemigoAvanzado.transform.position, enemigoAvanzado.jugador.transform.position) > enemigoAvanzado.rangoAtaque)
            {
                tiempoSalida += Time.deltaTime;
                if (tiempoSalida > tiempoAntesDeSalir)
                {
                    enemigoAvanzado.maquinita.CambiarEstado(enemigoAvanzado.estadoPerseguir);
                }
            }
            else
            {
                tiempoSalida = 0;
            }
        }
    }
}
