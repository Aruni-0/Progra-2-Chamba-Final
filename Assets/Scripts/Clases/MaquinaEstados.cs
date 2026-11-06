using UnityEngine;

public class MaquinaEstados
{
    public EstadoEnemigo estadoActual;

    public void Inicializar(EstadoEnemigo nuevoEstado)
    {
        estadoActual = nuevoEstado;
        nuevoEstado.EntrarEstado();
    }

    public void CambiarEstado(EstadoEnemigo nuevoEstado)
    {
        estadoActual.SalirEstado();
        estadoActual = nuevoEstado;
        estadoActual.EntrarEstado();
    }
}
