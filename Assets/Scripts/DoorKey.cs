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
        // Player referans�n� al�yoruz (bu sat�r player'� do�ru �ekilde bulmal�s�n�z)
        player = FindObjectOfType<Player>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // �arpan nesnenin "Player" tag'ine sahip olup olmad���n� kontrol et
        if (collision.gameObject.CompareTag("Player"))
        {
            player.Key = true;
            KeyUI.SetActive(true);
            Destroy(gameObject); // Anahtar nesnesini yok et
        }
    }


}
