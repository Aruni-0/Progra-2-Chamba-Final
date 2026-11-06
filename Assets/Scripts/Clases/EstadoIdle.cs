using UnityEngine;
using UnityEngine.AI;

public class EstadoIdle : EstadoEnemigo
{
    private Vector3 posicionObjetivo;

    public EstadoIdle(EnemigoAvanzado _enemigoAvanzado, MaquinaEstados _maquina) : base(_enemigoAvanzado, _maquina)
    {

    }

    public override void EntrarEstado()
    {
        base.EntrarEstado();

        PosicionRandom();
        enemigoAvanzado.agente.SetDestination(posicionObjetivo);

    }

    public override void SalirEstado()
    {
        base.SalirEstado();
    }
    public override void FrameUpdate()
    {
        if ((enemigoAvanzado.transform.position - posicionObjetivo).magnitude < 0.1f)
        {
            PosicionRandom();
            enemigoAvanzado.agente.SetDestination(posicionObjetivo);
        }
        base.FrameUpdate();
    }

    public void PosicionRandom()
    {
        bool posicionEncontrada = false;
        while (!posicionEncontrada)
        {
            Vector3 _posicion = enemigoAvanzado.transform.position + (Vector3)UnityEngine.Random.insideUnitSphere * enemigoAvanzado.rangoMovimientoRandom;
            _posicion.y = 0;

            if (NavMesh.SamplePosition(_posicion, out NavMeshHit hit, 0.1f, NavMesh.AllAreas))
            {
                posicionObjetivo = _posicion;
                posicionEncontrada = true;
            }
        }
    }
}
