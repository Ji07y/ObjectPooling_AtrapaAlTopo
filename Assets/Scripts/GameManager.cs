using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEditor;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject(typeof(GameManager).Name);
                    instance = singleton.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    public int puntaje = 0;
    public float tiempoLimite = 60f;
    private float tiempoActual = 0f;
    private bool estaEnJuego = false;

    public GameObject prefabTopo;
    public TextMeshProUGUI textoPuntaje;
    public TextMeshProUGUI textoTiempo;

    public delegate void ScoreUpdatedHandler(int newScore);
    public event ScoreUpdatedHandler OnScoreUpdated;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        tiempoActual = tiempoLimite;
        ActualizarInterfaz();
        IniciarJuego();
    }

    void IniciarJuego()
    {
        StartCoroutine(CicloTopos());
    }

    IEnumerator CicloTopos()
    {
        while (!FinDelJuego())
        {
            yield return new WaitForSeconds(2f);
            MostrarTopo();
        }
    }


    void MostrarTopo()
    {
        GameObject topo = TopoObjectPool.Instance.ObtenerTopo();

        if (topo != null)
        {
            // Selecciona un agujero aleatorio
            GameObject agujeroAleatorio = ObtenerAgujeroAleatorio();

            if (agujeroAleatorio != null)
            {
                // Obtén la posición del agujero
                Vector3 agujeroPosition = agujeroAleatorio.transform.position;

                // Coloca el topo sobre el agujero
                topo.transform.position = agujeroPosition;
                topo.SetActive(true);

                // Lógica adicional si es necesaria
                StartCoroutine(OcultarTopoDespuesDeMostrar(topo));
            }
        }
        else
        {
            Debug.LogError("No se pudo obtener un topo del Object Pool.");
        }
    }
    GameObject ObtenerAgujeroAleatorio()
    {
        GameObject[] agujeros = GameObject.FindGameObjectsWithTag("agujeros");

        if (agujeros.Length > 0)
        {
            return agujeros[Random.Range(0, agujeros.Length)];
        }

        Debug.LogError("No se encontraron agujeros para los topos.");
        return null;
    }
    IEnumerator OcultarTopoDespuesDeMostrar(GameObject topo)
    {
        
        yield return new WaitForSeconds(1.0f);

        if (topo != null)
        {
            topo.GetComponent<TopoController>().OcultarTopo();
        }
    }

    void Update()
    {
        if (!estaEnJuego)
        {
            tiempoActual -= Time.deltaTime;
            if (tiempoActual <= 0f)
            {
                // Cambiar a la escena de fin de juego
                SceneManager.LoadScene("GameOver");
                return;
            }
            ActualizarInterfaz();
        }
    }

    void ActualizarInterfaz()
    {
        textoPuntaje.text = "Puntaje: " + puntaje;
        textoTiempo.text = "Tiempo: " + Mathf.Round(tiempoActual);
    }

    public void AumentarPuntaje(int puntos)
    {
        puntaje += puntos;
        OnScoreUpdated?.Invoke(puntaje);
    }

    public bool FinDelJuego()
    {
        return estaEnJuego;
    }
    public void CambiarAEscena(string nombreDeLaEscena)
    {
        SceneManager.LoadScene("Juego");
    }
}

