using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour,IDropHandler
{
    public Sprite sprite;
    public GameObject kagit;
    public GameObject gameController;
    public GameObject DamgaSlot;
    public Sprite DamgaSprite;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Müşteriye verildi");
        if (kagit.GetComponent<DragDrop>().damgali)
        {
            gameController.GetComponent<GameController>().check(true);
            kagit.GetComponent<DragDrop>().damgali = false;
            kagit.transform.GetChild(kagit.transform.childCount - 1).GetComponent<Image>().sprite = sprite;
            

        }
        else if (!kagit.GetComponent<DragDrop>().damgali)
        {
            gameController.GetComponent<GameController>().check(false);
            kagit.GetComponent<DragDrop>().damgali = false;
        }
        kagit.transform.position = kagit.GetComponent<DragDrop>().startPos;
        kagit.GetComponent<CanvasGroup>().alpha = 1f;
        kagit.GetComponent<CanvasGroup>().blocksRaycasts = true;
        kagit.GetComponent<RectTransform>().localScale = new Vector3(0,0,1);
        DamgaSlot.GetComponent<Image>().sprite = DamgaSprite;
        DamgaSlot.GetComponent<Image>().color = new Color(1, 1, 1, 0.2745098f);
        kagit.SetActive(false);
        
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
