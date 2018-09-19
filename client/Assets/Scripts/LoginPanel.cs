using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UniRx;
public class LoginPanel : MonoBehaviour {

    public Manager manager;
    public InputField userInput, passInput;
  
    
    public Text error;

    public void OpenRegister()
    {
        manager.SetPanel(PANEL.Register);
    }

   

    public void Register()
    {

        if(userInput.text == "")
        {
            error.text = "username is not empty";
            error.gameObject.SetActive(true);
            return;
        }

      

        if(passInput.text == "" )
        {
            error.text = "Pass is not similar";
            error.gameObject.SetActive(true);
            return;
        }


        WWWForm form = new WWWForm();
        Registry.username = userInput.text;
        Registry.password = passInput.text;
        form.AddField("username", userInput.text);
        form.AddField("password", passInput.text);
        ObservableWWW.Post(Constants.API_LOGIN, form)
                   .Subscribe(
                       x =>
                       {
                           Debug.Log("[*] Login success");
                           manager.SetPanel(PANEL.Menu);
                       }, // onSuccess
                       ex =>
                       {
                           error.text = ex.ToString();
                           error.gameObject.SetActive(true);
                       }); // onError



    }


}
