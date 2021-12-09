using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
 
public class PostMethod : MonoBehaviour
{
    InputField username;
    InputField password;
 
    void Start()
    {
        username = GameObject.Find("InputField-username").GetComponent<InputField>();
        password = GameObject.Find("InputField-password").GetComponent<InputField>();
        GameObject.Find("ConnectButton").GetComponent<Button>().onClick.AddListener(PostData);
    }
 
    void PostData() => StartCoroutine(PostData_Coroutine());
 
    IEnumerator PostData_Coroutine()
    {
        string uri = "https://nftbattleapi.beacontracker.software/login";
        WWWForm form = new WWWForm();
        form.AddField("name", username.text);
        form.AddField("password", password.text);
        using(UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {
            yield return request.SendWebRequest();
            Debug.Log(request.downloadHandler.text);
            if (request.isNetworkError || request.isHttpError)
                Debug.Log(request.error);
            else
                Debug.Log(request.downloadHandler.text);
        }
    }
}
