using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    private Player player;



    private void Start()
    {
        // Player referans�n� al�yoruz (bu sat�r player'� do�ru �ekilde bulmal�s�n�z)
        player = FindObjectOfType<Player>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // �arpan nesnenin "Player" tag'ine sahip olup olmad���n� kontrol et
        if (collision.gameObject.CompareTag("Player"))
        {
            player.healthUp = true; 
            Destroy(gameObject); // Anahtar nesnesini yok et
        }
    }
}
