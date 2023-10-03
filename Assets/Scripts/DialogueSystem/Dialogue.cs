using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue : Interactable
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI charName;
    public string[] box;
    public string[] names;
    public float textSpeed;
    public GameObject DialogueUI;
    public string returntex;
    private int index;
    private int indexForname;
    [HideInInspector] public bool IsDialogueAct = false;
    public bool isNpcDissapear = false;
    void Awake()
    {

    }
    public override void Interact()
    {  // Starting dialogue - disabling player movement 
        StopAllCoroutines();
        DialogueUI.SetActive(true);
        textComponent.text = string.Empty;
        StartDialogue(); 
        GameObject.Find("FirstPersonController").GetComponent<FirstPersonController>().playerCanMove = false;
        IsDialogueAct = true;
        gameObject.GetComponent<Collider>().enabled = !gameObject.GetComponent<Collider>().enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDialogueAct){
            if(Input.GetMouseButtonDown(0)){
            if (textComponent.text == box[index]){
                NextLine();
                NextName();
            }
            else{
                StopAllCoroutines();
                textComponent.text = box[index];
            }
        }
        }
        
    }

    void StartDialogue(){
        index =0;
        indexForname = 0;
        StartCoroutine(TypeLine());
        charName.text = names[indexForname];
    }

    IEnumerator TypeLine(){
        foreach (char c in box[index].ToCharArray())
        {
            textComponent.text +=c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine(){
        if (index < box.Length-1){
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        //End of dialogue - enabling everything
        else{
            DialogueUI.SetActive(false);
            GameObject.Find("FirstPersonController").GetComponent<FirstPersonController>().playerCanMove = true;
            IsDialogueAct = false;
            gameObject.GetComponent<Collider>().enabled = !gameObject.GetComponent<Collider>().enabled;
            if (isNpcDissapear) gameObject.SetActive(false);
        }
    }
    void NextName(){
        if (indexForname < names.Length-1){
            indexForname++;
            charName.text = names[indexForname];
        }
        else
        {
            charName.text = string.Empty;
        }
    }
    public override string GetDescription()
    {
       return returntex;
    }
}
