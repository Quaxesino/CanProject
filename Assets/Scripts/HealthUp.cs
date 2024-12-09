using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    private Player player;



    private void Start()
    {
        // Player referansýný alýyoruz (bu satýr player'ý doðru þekilde bulmalýsýnýz)
        player = FindObjectOfType<Player>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Çarpan nesnenin "Player" tag'ine sahip olup olmadýðýný kontrol et
        if (collision.gameObject.CompareTag("Player"))
        {
            player.healthUp = true; 
            Destroy(gameObject); // Anahtar nesnesini yok et
        }
    }
}
