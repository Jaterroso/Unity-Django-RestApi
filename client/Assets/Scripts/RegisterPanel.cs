using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UniRx;
public class RegisterPanel:MonoBehaviour
{
    public Manager manager;
    public InputField userInput, emailInput, pass1Input, pass2Input;
    public void OpenLogin()
    {
        manager.SetPanel(PANEL.Login);
    }
    // Use this for initialization
    public Text error;

    public void Register()
    {
        if(userInput.text == "")
        {
            error.text = "username is not empty";
            error.gameObject.SetActive(true);
            return;
        }

        if(emailInput.text == "")
        {
            error.text = "email is not empty";
            error.gameObject.SetActive(true);
            return;
        }

        if(pass1Input.text == "" || pass1Input.text != pass2Input.text)
        {
            error.text = "Pass is not similar";
            error.gameObject.SetActive(true);
            return;
        }


        WWWForm form = new WWWForm();

        form.AddField("username", userInput.text);
        form.AddField("email", emailInput.text);
        form.AddField("password1", pass1Input.text);
        form.AddField("password2", pass2Input.text);
        Registry.username = userInput.text;
        Registry.password = pass1Input.text;
        ObservableWWW.Post(Constants.API_REGISTER, form).Subscribe(
            x =>
            {
                Debug.Log("[*] Registing success");
                manager.SetPanel(PANEL.Menu);
            }, // onSuccess
            ex =>
            {
                Debug.Log("[*] Error: " + ex.ToString());
                error.text = ex.ToString();
                error.gameObject.SetActive(true);
            }); // onError



    }


}
