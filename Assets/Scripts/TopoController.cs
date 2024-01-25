using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopoController : MonoBehaviour
{
    public int puntos = 10;

    void OnMouseDown()
    {
        if (!GameManager.Instance.FinDelJuego())
        {
            GameManager.Instance.AumentarPuntaje(puntos);
            OcultarTopo();
        }
    }

    public void MostrarTopo()
    {
        // L�gica para la aparici�n del topo, por ejemplo, animaciones.
        // En este caso, ya no necesitar�s cambiar la posici�n, ya que se establece al instanciar el prefab.
        gameObject.SetActive(true);
    }

    public void OcultarTopo()
    {
        gameObject.SetActive(false);
    }
}
