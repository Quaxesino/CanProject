using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Player player;

    public GameObject Win;
    public GameObject Warning;


    private void Start()
    {
        // Player referansýný alýyoruz (bu satýr player'ý doðru þekilde bulmalýsýnýz)
        player = FindObjectOfType<Player>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player.Key)
            {
                Win.SetActive(true);
            }
            else
            {
                StartCoroutine(WarningText());
            }
        }
       
    }

    private IEnumerator WarningText()
    {
        Warning.SetActive(true);  // Objeyi aktif et

        // 3 saniye bekle
        yield return new WaitForSeconds(3f);

        Warning.SetActive(false);  // Objeyi 3 saniye sonra pasif yap
    }
}
