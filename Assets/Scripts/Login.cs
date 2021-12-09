using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public string sceneName;
    string username;
    string password;
    string loginJson;
    public class UserData 
    {
        public string name;
        public string password;
    }

    public void OnButtonPress()
    {
        username = GameObject.Find("InputField-username").GetComponent<InputField>().text;
        password = GameObject.Find("InputField-password").GetComponent<InputField>().text;
        StartCoroutine(LoginPost(username, password));
    }
 
    public IEnumerator LoginPost(string username, string password)
    {
        //@TODO: call API login
        // Add Token to headers

        var user = new UserData();
        user.name = username;
        user.password = password;

        string json = JsonUtility.ToJson(user);

        var req = new UnityWebRequest("https://nftbattleapi.beacontracker.software/login", "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        req.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return req.SendWebRequest();

        if (req.isNetworkError)
        {
            Debug.Log("Error While Sending: " + req.error);
        }
        else
        {
            Debug.Log("Received: " + req.downloadHandler.text);
            if (!req.downloadHandler.text.Contains("não")){
                SceneManager.LoadScene(sceneName);
            }
        }

    }
}
