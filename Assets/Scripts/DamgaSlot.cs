using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DamgaSlot : MonoBehaviour, IDropHandler
{
    public Sprite sprites;
    public GameObject kagit;
    public AudioClip plop;
    
    
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Damga Basıldı");
        kagit.GetComponent<DragDrop>().damgali = true;
        GetComponent<Image>().sprite = sprites;
        GetComponent<Image>().color = new Color(1, 1, 1, 1);
        GetComponent<AudioSource>().PlayOneShot(plop);

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
