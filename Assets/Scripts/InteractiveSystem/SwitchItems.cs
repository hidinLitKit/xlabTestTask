using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class SwitchItems : MonoBehaviour
{
    public GameObject menuInventory;
    //menuInventory это не Inventory это originPoint (тупую иерархию сделал..)
    public GameObject InventoryUI;
    //public Image image;
    public TextMeshProUGUI Name;
    public int selectedItem;
    public AudioSource SwitchSound;
    private bool canSwitch = true;
    // Start is called before the first frame update
    void Start()
    {
        SelectItem();
        InventoryUI.SetActive(false);
        //StartCoroutine(FadeInventory());
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedItem = selectedItem;
        if (canSwitch && Input.GetAxis("Mouse ScrollWheel")>0f) //выбор номера слота предмета
        {
            if (selectedItem >= transform.childCount-1)
            {
                selectedItem = 0;
                menuInventory.transform.DOLocalRotate( new Vector3(0,0,0),0.3f);
            }
            else{
                 selectedItem++;
                 menuInventory.transform.DOLocalRotate(menuInventory.transform.localEulerAngles + new Vector3(0, 45, 0),0.3f);
                
            }
            SwitchSound.Play();
            
            
     
        }
        if (canSwitch && Input.GetAxis("Mouse ScrollWheel")<0f)
        {
            if (selectedItem <= 0)
            {
                selectedItem = transform.childCount-1;
                menuInventory.transform.DOLocalRotate(new Vector3(0, (transform.childCount-1)*45, 0),0.3f);
        
            }
            else{
                 selectedItem--;
                 menuInventory.transform.DOLocalRotate(menuInventory.transform.localEulerAngles + new Vector3(0, -45, 0),0.3f);
            }
            SwitchSound.Play();
            
     
        }
        

        if (previousSelectedItem!=selectedItem || (transform.childCount==1 && selectedItem==0)){
            SelectItem();
        }
    }
    public void SelectItem(){
        int i = 0;
        foreach(Transform item in transform){
            if (i == selectedItem){
                StopAllCoroutines();
                item.gameObject.SetActive(true); //new item
                Name.text = item.gameObject.GetComponent<PickedItemProps>().itemname;
                

                StartCoroutine(coolDown());
                

                //иконка не нужны сейчас
                //image.sprite = item.gameObject.GetComponent<PickedItemProps>().img;
                //StartCoroutine(FadeInventory());
                
            }
            else {
                item.gameObject.SetActive(false);
            }
            i++;

        }
        
    }

    IEnumerator FadeInventory(){
        yield return new WaitForSeconds(3f);
        InventoryUI.GetComponent<CanvasGroup>().DOFade(0f,1f );
        yield return new WaitForSeconds(1f);
        InventoryUI.SetActive(false);
    }
    IEnumerator coolDown()
    {
        canSwitch = false;
        yield return new WaitForSeconds(0.5f);
        canSwitch = true;
    }
}
