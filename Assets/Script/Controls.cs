using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float hareketHizi = 5f; // Karakterin hareket h�z�
    public float ziplamaGucu = 10f;      // Z�plama g�c�
    private bool yereDegdi = false; // Karakterin yerde olup olmad���n� kontrol et
    private bool ilkDusus = true;   // �lk d����� kontrol et

    void Update()
    {
        // Klavye girdilerini almak i�in Input s�n�f�n� kullan�yoruz
        float yatayHareket = Input.GetAxis("Horizontal");
        float dikeyHareket = Input.GetAxis("Vertical");

        // Hareket vekt�r�n� olu�turuyoruz
        Vector3 hareket = new Vector3(yatayHareket, 0f, dikeyHareket) * hareketHizi * Time.deltaTime;

        //Z�plama
        if (yereDegdi && Input.GetButtonDown("Jump"))
        {
            Debug.Log("Z�plama i�lemi ger�ekle�ti!");
            GetComponent<Rigidbody>().AddForce(Vector3.up * ziplamaGucu, ForceMode.Impulse);
            yereDegdi = false;
        }

        // Karakter hareket 
        transform.Translate(hareket);

        // Yere temas kontrol�
        if (ilkDusus)
        {
            if (!yereDegdi)
            {
                Vector3 rayBaslangicNoktasi = transform.position; // Karakterin alt noktas�
                Vector3 rayYonu = Vector3.down; // A�a�� y�nde bir ray
                float rayUzunlugu = 0.1f; // Ray'�n uzunlu�u

                RaycastHit hit;
                if (Physics.Raycast(rayBaslangicNoktasi, rayYonu, out hit, rayUzunlugu, LayerMask.GetMask("Zemin")))
                {
                    ilkDusus = false; // �lk d���� tamamland�
                    yereDegdi = true;  // Yere temas var
                    

                }
                else
                {
                    
                    yereDegdi = false;
                }
            }
        }
    }
}
