using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorKey : MonoBehaviour
{
    private Player player;
    public GameObject KeyUI;


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
            player.Key = true;
            KeyUI.SetActive(true);
            Destroy(gameObject); // Anahtar nesnesini yok et
        }
    }


}
