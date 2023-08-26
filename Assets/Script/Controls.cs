using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float hareketHizi = 5f; // Karakterin hareket hýzý
    public float ziplamaGucu = 10f;      // Zýplama gücü
    private bool yereDegdi = false; // Karakterin yerde olup olmadýðýný kontrol et
    private bool ilkDusus = true;   // Ýlk düþüþü kontrol et

    void Update()
    {
        // Klavye girdilerini almak için Input sýnýfýný kullanýyoruz
        float yatayHareket = Input.GetAxis("Horizontal");
        float dikeyHareket = Input.GetAxis("Vertical");

        // Hareket vektörünü oluþturuyoruz
        Vector3 hareket = new Vector3(yatayHareket, 0f, dikeyHareket) * hareketHizi * Time.deltaTime;

        //Zýplama
        if (yereDegdi && Input.GetButtonDown("Jump"))
        {
            Debug.Log("Zýplama iþlemi gerçekleþti!");
            GetComponent<Rigidbody>().AddForce(Vector3.up * ziplamaGucu, ForceMode.Impulse);
            yereDegdi = false;
        }

        // Karakter hareket 
        transform.Translate(hareket);

        // Yere temas kontrolü
        if (ilkDusus)
        {
            if (!yereDegdi)
            {
                Vector3 rayBaslangicNoktasi = transform.position; // Karakterin alt noktasý
                Vector3 rayYonu = Vector3.down; // Aþaðý yönde bir ray
                float rayUzunlugu = 0.1f; // Ray'ýn uzunluðu

                RaycastHit hit;
                if (Physics.Raycast(rayBaslangicNoktasi, rayYonu, out hit, rayUzunlugu, LayerMask.GetMask("Zemin")))
                {
                    ilkDusus = false; // Ýlk düþüþ tamamlandý
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
