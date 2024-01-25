using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopoObjectPool : MonoBehaviour
{

    public GameObject prefabTopo;
    public int tamanoPiscina = 10;

    private List<GameObject> piscinaTopos;

    public static TopoObjectPool Instance;

    void Awake()
    {
        Instance = this;
        piscinaTopos = new List<GameObject>();

        for (int i = 0; i < tamanoPiscina; i++)
        {
            CrearNuevoTopo();
        }
    }

    void CrearNuevoTopo()
    {
        GameObject topo = Instantiate(prefabTopo, transform);
        topo.SetActive(false);
        piscinaTopos.Add(topo);
    }

    public GameObject ObtenerTopo()
    {
        foreach (var topo in piscinaTopos)
        {
            if (!topo.activeInHierarchy)
            {
                return topo;
            }
        }

        // Si todos están en uso, crea uno nuevo
        CrearNuevoTopo();
        return piscinaTopos[piscinaTopos.Count - 1];
    }
}


