using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicio : MonoBehaviour
{


    [SerializeField]
    GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {

    gameOver.SetActive(false);

    }


    public void GameOverTrue()
    {

        gameOver.SetActive(true);

    }


    public void GameOverFalse()
    {

        gameOver.SetActive(false);

    }

}
