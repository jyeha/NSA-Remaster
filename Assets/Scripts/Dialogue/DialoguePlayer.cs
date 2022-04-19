using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialoguePlayer : MonoBehaviour
{
    [SerializeField]
    Dialogue[] dialogues;

    GameObject gameManager;

    private UserClass userdata;

    public Text nameText, contextText;
    public Image characterImage;

    bool isNext = false;
    int lineCount = 0;
    int contextCount = 0;

    void Start(){
        gameManager = GameObject.Find("GameManager");
        userdata = gameManager.GetComponent<GameManager>().UserData;
        this.dialogues = GetComponent<DialogueDatabase>().dialogues;
        StartDialogue();
    }

    void Update(){
        if(isNext){
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
                isNext = false;
                contextText.text = "";
                if(++contextCount < dialogues[lineCount].contexts.Length){
                    StartCoroutine(PlayDialogue());
                }else{
                    contextCount = 0;
                    if(++lineCount < dialogues.Length){
                        StartCoroutine(PlayDialogue());
                    }else{
                        EndDialogue();
                    }
                }
                
            }
        }
    }

    IEnumerator PlayDialogue(){
        string replaceText = dialogues[lineCount].contexts[contextCount];
        replaceText = replaceText.Replace("`", ",");
        
        
        if(dialogues[lineCount].name == "player"){
            nameText.text = userdata.name;
            characterImage.sprite = Resources.Load<Sprite>("Images/Backgrounds/transparent");
        }
        else{
            nameText.text = dialogues[lineCount].name;

            characterImage.sprite = Resources.Load<Sprite>("Images/Characters/"+dialogues[lineCount].image);    
        }

        for(int i=0;i<replaceText.Length;i++){
            contextText.text = replaceText.Substring(0, i+1);
            yield return new WaitForSeconds(0.05f);
        }

        isNext = true;
    }

    void StartDialogue(){
        contextText.text = "";
        nameText.text = "";

        StartCoroutine(PlayDialogue());
    }

    void EndDialogue(){
        contextCount = 0;
        lineCount = 0;
        dialogues = null;
        isNext = false;

        SceneManager.LoadScene("HomeScene");
    }

}
