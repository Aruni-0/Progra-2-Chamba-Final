using UnityEngine;

[CreateAssetMenu(fileName = "EnemigosSO", menuName = "Scriptable Objects/EnemigosSO")]
public class EnemigosSO : ScriptableObject
{
    public int vida;
    public float velocidad;
    public int daño;
    public GameObject objeto;
}
