using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDatabase : MonoBehaviour
{
    public static DialogueDatabase instance;
    public static bool isFinish;

    [SerializeField]
    string csvFileName;
    //Dictionary<int, Dialogue> dialogueDic = new Dictionary<int, Dialogue>();

    
    public Dialogue[] dialogues;

    void Awake(){
        if(instance == null){
            instance = this;
            DialogueParser theParser = GetComponent<DialogueParser>();
            dialogues = theParser.Parse(csvFileName);

            // Debug.Log(dialogues[0].name);
            // Debug.Log(dialogues[1].contexts);

            // for(int i=0;i<dialogues.Length;i++){
            //     dialogueDic.Add(i+1, dialogues[i]);
            // }

            isFinish = true;
        }
    }

    public Dialogue[] GetDialogues(){
        // List<Dialogue> dialogueList = new List<Dialogue>();

        // for(int i=0;i<=endLine - startLine;i++){
        //     dialogueList.Add(dialogueDic[startLine+i]);
        // }

        // return dialogueList.ToArray();
        return dialogues;
    }
}
