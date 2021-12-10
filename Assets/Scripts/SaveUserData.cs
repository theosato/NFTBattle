using System.IO;
using UnityEngine;
using UnityEngine.UI;
 
public class JsonReadWriteSystem : MonoBehaviour
{
    public void SaveLoginToJson(string username, string wallet, string jwt)
    {
        UserData data = new UserData();
        data.username = username;
        data.wallet = wallet;
        data.jwt = jwt;
 
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/UserDataFile.json", json);
    }
 
    public void LoadFromJson()
    {

        string json = File.ReadAllText(Application.dataPath + "/WeaponDataFile.json");
        UserData data = JsonUtility.FromJson<UserData>(json);
 
        // idInputField.text = data.Id;
        // nameInputField.text = data.Name;
        // infoInputField.text = data.Information;
    }
}
