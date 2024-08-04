using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField] float destroyDelay = 0.5f;   
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent <SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!"); 
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        //if(the thing we trigger is the package)
        // {
        //then print "package picked up" to the console
        // }
        if (other.tag == "Package" && !hasPackage) // paketin etiketi uyuyorsa ve paket alýnmamýþsa topla(daha önce paketi) paketi    
        {                                                         //(daha önce paketi) paketi
            Debug.Log("Package picked up");
            hasPackage= true;   
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject,destroyDelay);
           
        }

        if(other.tag == "Customer" && hasPackage)   // (==) is it true or not?  Does the left equel to right?
        {
            Debug.Log("Package delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
           
        }
    }

}
