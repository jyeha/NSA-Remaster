using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance; // singleton
    static OperatorClass _selected;
    //OwnOperatorList OpList;


    public static GameManager Instance{
        get{
            if(!_instance){
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if(_instance == null){
                   Debug.Log("no singleton object") ;
                }
            }
            return _instance;
        }
    }

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    private void Awake(){
        if(_instance == null)
            _instance = this;
        else if(_instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    // SceneChangeFunctions
    public void GotoHome(){
        //GameObject obj;
        if(SceneManager.GetActiveScene().name=="HomeScene"){
            //obj = GameObject.Find("");
        }
        SceneManager.LoadScene("HomeScene");
    }
    public void GotoOperator(){
        //GameObject obj;
        if(SceneManager.GetActiveScene().name=="OperatorScene"){
            //obj = GameObject.Find("");
        }
        SceneManager.LoadScene("OperatorScene");
    }
    public void GotoSquad(){
        //GameObject obj;
        if(SceneManager.GetActiveScene().name=="SquadsScene"){
            //obj = GameObject.Find("");
        }
        SceneManager.LoadScene("SquadsScene");
    }
    public void GotoOperatorDetail(){
        //GameObject obj;
        if(SceneManager.GetActiveScene().name=="OperatorDetailScene"){
            //obj = GameObject.Find("");
        }
        SceneManager.LoadScene("OperatorDetailScene");
    }
    public void GotoGacha(){
        //GameObject obj;
        if(SceneManager.GetActiveScene().name=="GachaScene"){
            //obj = GameObject.Find("");
        }
        SceneManager.LoadScene("GachaScene");
    }
    public void GotoGachaResult(){
        //GameObject obj;
        if(SceneManager.GetActiveScene().name=="GachaResultScene"){
            //obj = GameObject.Find("");
        }
        SceneManager.LoadScene("GachaResultScene");
    }


    // for Json data
    string ObjectToJson(object obj){
        return JsonUtility.ToJson(obj);
    }
    T JsonToObject<T>(string json){
        return JsonUtility.FromJson<T>(json);
    }
    void CreatetoJsonFile(string createPath, string filename, string jsonData){
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, filename), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }
    public T LoadJsonFile<T>(string loadPath, string fileName)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.OpenOrCreate);
        
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        return JsonUtility.FromJson<T>(jsonData);
    }
}
