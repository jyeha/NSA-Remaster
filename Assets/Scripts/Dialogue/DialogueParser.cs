using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CSVFileName){
        List<Dialogue> dialogueList = new List<Dialogue>();
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);

        // Enter 기준으로 parsing
        string[] data = csvData.text.Split(new char[]{'\n'});
        
        // 각 줄 마다 ID, name, sentence로 파싱
        for(int i=1;i<data.Length;){
            string[] row = data[i].Split(new char[]{','});

            Dialogue dialogue = new Dialogue();
            dialogue.name = row[1];
            
            string tmp = row[3].Substring(0, row[3].Length-1);
            dialogue.image =tmp;
            
            List<string> contextList = new List<string>();
    

            do{
                contextList.Add(row[2]);

                if(++i<data.Length){
                    row = data[i].Split(new char[]{','});
                }else{
                    break;
                }
            }while(row[0].ToString() == "");
            
            dialogue.contexts = contextList.ToArray();

            dialogueList.Add(dialogue);

        }

        return dialogueList.ToArray();
    }

}
