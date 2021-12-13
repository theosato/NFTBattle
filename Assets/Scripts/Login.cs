using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public class Login : MonoBehaviour
{
    public string sceneName;
    string username;
    string password;
    string loginJson;
    public class UserInfo
    {
        public string name;
        public string password;
    }

    public class UserAccount
    {
        public string id;
        public string name;
        public string walletId;
    }

    public class LoginResponse
    {
        public string token;
        public string type;
        public UserAccount user;
    }

    public class NFT
    {
        public string Id;
        public string Token_id;
        public string Image_url;
        public string Name;
        public int Attack;
        public int Defence;
        public int Health;

    }
    public void SaveLoginToJson(string username, string wallet, string jwt, List<string> monsters)
    {
        UserData data = new UserData();
        data.username = username;
        data.wallet = wallet;
        data.jwt = jwt;
        data.monsters = monsters;
 
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/UserDataFile.json", json);
    }

    public void OnButtonPress()
    {
        // username = GameObject.Find("InputField-username").GetComponent<InputField>().text;
        // password = GameObject.Find("InputField-password").GetComponent<InputField>().text;
        // StartCoroutine(LoginPost(username, password));
        SceneManager.LoadScene(sceneName);
    }
 
    public IEnumerator LoginPost(string username, string password)
    {
        //@TODO: call API login
        // Add Token to headers

        var user = new UserInfo();
        user.name = username;
        user.password = password;

        string json = JsonUtility.ToJson(user);

        var req = new UnityWebRequest("https://nftbattleapi.beacontracker.software/login", "POST");
        var nftRequest = new UnityWebRequest("https://nftbattleapi.beacontracker.software/usernft", "GET");
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
            if (!req.downloadHandler.text.Contains("Usuário não encontrado")){

                string response = System.Text.Encoding.UTF8.GetString(req.downloadHandler.data);
                LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(response);
                Debug.Log("Token: " + loginResponse.token);
                Debug.Log("Name: " + loginResponse.user.name);
                Debug.Log("Wallet: " + loginResponse.user.walletId);
                string[] monsters = { "Growlmon", "Catmon", "Metalmonster" };
                List<string> monstersRange = new List<string>(monsters);
                SaveLoginToJson(loginResponse.user.name, loginResponse.user.walletId, loginResponse.token, monstersRange);
                SceneManager.LoadScene(sceneName);
            }
        }

    }
}
