using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class inimigoVida : MonoBehaviour
{
    public int vidaInimigo = 1;
    public int vidaAtual;
    
    
    void Start()
    {
        vidaAtual = vidaInimigo;
    }

    
    void Update()
    {
        
    }

    public void ReceberDano() {
        vidaAtual -= 1;

        if(vidaAtual <= 0)
        {
            Debug.Log("Morreu");

        }
    }
}
public class Collider
{
    private void OnTriggerEnter2d(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<inimigoVida>().ReceberDano();
        
        }
    }  
    

}