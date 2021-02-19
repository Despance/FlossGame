using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public int customerNumber = 9;
    public int rigthNow = -1;
    public GameObject[] musteripanel;
    public GameObject musterikarti;
    public GameObject personDrag;
    public GameObject[] bakmapanel;
    Color[] colorList;
    public GameObject person;
    Vector3 personStartPos;
    public Sprite[] personSprite;
    
    public GameObject missionPanel;
    public GameObject realText;
    public Sprite[] sprites;
    private int points = 0;
    private int cusCount=0;
    private int lives = 3;
    public Sprite deadlive;


    public Text customerText;
    public GameObject lifeObject;

    List<Item> itemList = new List<Item>();
    List<Item> realItemList = new List<Item>();
    
    

    public bool gameStarted = false;


    public AudioClip footStep, correctSound, incorrectSound,winSound,loseSound;
    AudioSource audioSource;


    public GameObject[] menu;
    
    void Start()
    {
        points = 0;
        audioSource = GetComponent<AudioSource>();
        personStartPos = person.transform.position;
       


        for (int i = 0; i < itemList.Count; i++)
        {
            Debug.Log(itemList[i].what+" "+ itemList[i].itemColor+" "+itemList[i].itemLocation+" "+itemList[i].itemShape+" "+itemList[i].itemTime );
        }
        
        
        
        

    }
    public void GameINIT()
    {


        for (int i = 0; i < customerNumber / 3; i++)
        {
            Item item = new Item("true");
            Item trickItem = new Item("trick");
            Item fakeItem = new Item("false");
            trickItem.itemColor = item.itemColor;
            trickItem.itemType = item.itemType;
            trickItem.itemShape = item.itemShape;
            trickItem.itemLocation = item.itemLocation;
            addImage(item);

            itemList.Add(trickItem);
            itemList.Add(item);
            realItemList.Add(item);
            itemList.Add(fakeItem);
        }
        for (int i = 0; i < itemList.Count; i++)
        {
            Item temp = itemList[i];
            int randomIndex = Random.Range(i, itemList.Count);
            itemList[i] = itemList[randomIndex];
            itemList[randomIndex] = temp;
        }




        for (int i = 0; i < realItemList.Count; i++)
        {
            Transform currentobject = missionPanel.transform.GetChild(i);
            currentobject.gameObject.SetActive(true);
            currentobject.GetChild(0).GetComponent<Text>().text = realItemList[i].itemType;
        }
            if (gameStarted)
        {
        musteriKart();
        customerText.text = "Customers Left:  " + (customerNumber - cusCount) + " / " + customerNumber;
        playerMovement("Enter");

        }
    }


    public void musteriKart()
    {
        rigthNow++;
        if (rigthNow > itemList.Count-1)
        {
            rigthNow = 0;
        }
        musteripanel[0].GetComponent<Text>().text = itemList[rigthNow].itemType;
        musteripanel[1].GetComponent<Text>().text = itemList[rigthNow].itemColor +", "+ itemList[rigthNow].itemShape;
        musteripanel[2].GetComponent<Text>().text = itemList[rigthNow].itemLocation;
        musteripanel[3].GetComponent<Text>().text = itemList[rigthNow].itemTime;
        
       
        
        
        
    }

    public void check(bool checker)
    {
        if (itemList[rigthNow].what == "true" && checker)
        {
            points++;
        }
        if((itemList[rigthNow].what == "true" && checker)|| (itemList[rigthNow].what == "false" && !checker) || (itemList[rigthNow].what == "trick" && !checker))
        {
            Debug.Log("PASS");
            playerMovement("Exit");
            cusCount++;
            personDrag.SetActive(false);
            audioSource.PlayOneShot(correctSound);
            
            
            for (int i = 0; i < realItemList.Count; i++)
            {
                Transform currentObject = missionPanel.transform.GetChild(i);
                if(realItemList[i].itemTime == itemList[rigthNow].itemTime)
                {
                    currentObject.GetComponent<Button>().interactable = false;
                    currentObject.GetComponentInChildren<Text>().color = Color.red;
                    realText.SetActive(false);
                }
            } 
            musteriKart();
        }
        else
        {
            Debug.Log("FAIL");
            playerMovement("Exit");
            cusCount++;
            lives--;
            lifeObject.transform.GetChild(lives).GetComponent<SpriteRenderer>().sprite = deadlive;
            personDrag.SetActive(false);
            musteriKart();
            audioSource.PlayOneShot(incorrectSound);
            

        }
    } 

    public void look(int which) {
        
        bakmapanel[0].GetComponent<Text>().text = realItemList[which].itemColor +", "+ realItemList[which].itemShape;
        bakmapanel[1].GetComponent<Text>().text = realItemList[which].itemLocation;
        bakmapanel[2].GetComponent<Text>().text = realItemList[which].itemTime;
        bakmapanel[3].GetComponent<Image>().sprite = realItemList[which].sprite;
        
        
         if (realItemList[which].itemColor == "Yellow")
        {
            bakmapanel[3].GetComponent<Image>().color = new Color(0.9019608f, 0.9019608f, 0.1533334f, 1);
        }
        else if (realItemList[which].itemColor == "Red")
        {
            bakmapanel[3].GetComponent<Image>().color = new Color(0.92f, 0.2959333f, 0.2392f, 1);
        }
        else if (realItemList[which].itemColor == "Purple")
        {
            bakmapanel[3].GetComponent<Image>().color = new Color(0.5652002f, 0.252f, 0.9f,1);
        }
        else if (realItemList[which].itemColor == "Green")
        {
            bakmapanel[3].GetComponent<Image>().color = new Color(0.2345098f, 0.9019608f, 0.4013726f, 1);
        }
        else if (realItemList[which].itemColor == "Blue")
        {
           bakmapanel[3].GetComponent<Image>().color = new Color(0.4472f, 0.74304f, 0.86f, 1);
        }
        else if (realItemList[which].itemColor == "Orange")
        {
            bakmapanel[3].GetComponent<Image>().color = new Color(0.9019608f, 0.5483922f, 0.1443138f, 1);
        }
        
        

        
        
        realText.SetActive(true);
        
    }
    

    void addImage(Item item)
    {
        if (item.itemType == "Ball")
        {
            if (item.itemShape =="Straight")
            {
                item.sprite = sprites[0];
            }else if (item.itemShape == "Stars")
            {
                item.sprite = sprites[1];
            }
            else if (item.itemShape == "Spotted")
            {
                item.sprite = sprites[2];
            }
        }else if (item.itemType == "Umbrella")
        {
            if (item.itemShape == "Straight")
            {
                item.sprite = sprites[3];
            }
            else if (item.itemShape == "Stars")
            {
                item.sprite = sprites[4];
            }
            else if (item.itemShape == "Spotted")
            {
                item.sprite = sprites[5];
            }
        }
        else if (item.itemType=="Wallet")
        {
            if (item.itemShape == "Straight")
            {
                item.sprite = sprites[6];
            }
            else if (item.itemShape == "Stars")
            {
                item.sprite = sprites[7];
            }
            else if (item.itemShape == "Spotted")
            {
                item.sprite = sprites[8];
            }
        }

        
    }
    void playerMovement(string state)
    {
        
        if(state == "Enter")
        {
            if (cusCount!=customerNumber && lives!=0){
          customerText.text = "Customers Left:  " + (customerNumber - cusCount) + " / " + customerNumber;
                audioSource.PlayOneShot(footStep);
            
            
            person.transform.DOMoveX(4, 3).OnComplete(() => Entered());}
        }else if(state == "Exit")
        {
            audioSource.PlayOneShot(footStep);
            person.transform.DOMoveX(20, 2).OnStepComplete(()=>playerMovement("Restart"));
        }else if (state == "Restart")
        {
            audioSource.Stop();
            person.GetComponent<SpriteRenderer>().sprite = personSprite[Random.Range(0, personSprite.Length - 1)];
            person.transform.position = personStartPos;
            if (lives == 0)
            {
                audioSource.Stop();
                menuControl(3);

            }
            else
            {
                playerMovement("Enter");
            }
            if (points == customerNumber/3 && lives>0)
            {
                audioSource.Stop();
                DOTween.KillAll();
                menuControl(2);
                
                
            }
            else {playerMovement("Enter"); }

            
        }

        
        
    }
    void Entered()
    {
        audioSource.Stop();
        personDrag.SetActive(true);
        musterikarti.SetActive(true);
        musterikarti.GetComponent<RectTransform>().DOScale(1.2f, 1);
    }
    public void menuControl(int state)
    {
        switch (state){
            case 0:
                menu[0].transform.GetChild(0).GetComponent<Button>().interactable = false;
                menu[1].GetComponent<RectTransform>().DOAnchorPosX(0, 1).SetEase(Ease.OutBounce);
                
                break;
            case 1:
                GameINIT();
                menu[2].transform.GetChild(0).GetComponent<Button>().interactable = false;
                menu[0].GetComponent<RectTransform>().DOAnchorPosY(1080, 1);
                menu[1].GetComponent<RectTransform>().DOAnchorPosY(1080, 1);
                menu[2].GetComponent<RectTransform>().DOAnchorPosY(1080, 1);
                

                break;

            case 2:
                menu[3].GetComponent<RectTransform>().DOAnchorPosY(0, 1).OnComplete(() => audioSource.PlayOneShot(winSound));
                break;
            case 3:
                menu[4].GetComponent<RectTransform>().DOAnchorPosY(0, 1).OnComplete(()=>audioSource.PlayOneShot(loseSound));
                break;

        }   
    }


    public void zorlukSec(int zorluk)
    {
        switch (zorluk)
        {
            case 1:
                customerNumber = 9;
                break;
            case 2:
                customerNumber = 18;
                break;
                    
            case 3:
                customerNumber = 27;
                break;
        }
        for (int i = 0; i < menu[1].transform.childCount; i++)
        {
            menu[1].transform.GetChild(i).GetComponent<Button>().interactable = false;
        }
        menu[2].GetComponent<RectTransform>().DOAnchorPosX(0, 1).SetEase(Ease.OutBounce);
    }

    [System.Obsolete]
    public void restartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    void Update()
    {
        
    }
}
