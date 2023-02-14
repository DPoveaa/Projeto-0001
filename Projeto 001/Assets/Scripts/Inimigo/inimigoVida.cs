using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class inimigoVida : MonoBehaviour
{
    public int vidaInimigo = 6;
    public int vidaAtual;
    
    

    void Start()
    {
        vidaAtual = vidaInimigo;
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            vidaAtual -= 1;
            if (vidaAtual == 3)
            {
                Debug.Log("Dano!");
            }
            else
            {

                if (vidaAtual <= 1)
                {
                    Debug.Log("Dano!");
                }
                else
                {
                    if (vidaAtual <= 0)
                    {
                        Debug.Log("Inimigo Morreu");
                        GameObject.Destroy(gameObject);


                    }

                }
            }

        }

    }
}

