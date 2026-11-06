public class EstadoEnemigo
{
    public MaquinaEstados maquina;

    public EnemigoAvanzado enemigoAvanzado;

    public virtual void EntrarEstado() { }
    public virtual void SalirEstado() { }
    public virtual void FrameUpdate() { }

    public EstadoEnemigo(EnemigoAvanzado _enemigoAvanzado, MaquinaEstados _maquina)
    {
        this.maquina = _maquina;
        this.enemigoAvanzado = _enemigoAvanzado;
    }
}
