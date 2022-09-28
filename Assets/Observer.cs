using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    // Start is called before the first frame update
    
    public bool m_IsPlayerInRange;



    public GameObject player;
    public GameEnding gameEnding;   
     void OnTriggerEnter(Collider other)
    {
       
        //gameEnding = GetComponent<GameEnding>();几把东西，害我找半天
        if (other.gameObject == player)
        {
           
            m_IsPlayerInRange = true;    
        }
    }   
    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }
    void Update()   
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.transform.position - transform.position + Vector3.up;
            Ray ray = new(transform.position,direction);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                if (hit.collider.gameObject == player)
                {
                    gameEnding.CaughtPlayer();  
                }
            }
           
        }
    }
}
