using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaJuego : MonoBehaviour
{
    public void CambiarAEscena(string nombreDeLaEscena)
    {
        SceneManager.LoadScene("Juego");


    }

   
}
