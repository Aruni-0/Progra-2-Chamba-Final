public class EstadoPerseguir : EstadoEnemigo
{
    public EstadoPerseguir(EnemigoAvanzado _enemigoAvanzado, MaquinaEstados _maquina) : base(_enemigoAvanzado, _maquina)
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
        enemigoAvanzado.agente.SetDestination(enemigoAvanzado.jugador.transform.position);
        base.FrameUpdate();
    }
}
