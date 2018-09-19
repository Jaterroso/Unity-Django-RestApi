using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class MenuPanel : MonoBehaviour {

    public Manager manager;
    public void OpenDoload()
    {
        manager.SetPanel(PANEL.Download);
    }

    public void OpenUpload()
    {
        manager.SetPanel(PANEL.Upload);
    }

    public void Logout()
    {
        WWWForm form = new WWWForm();
        ObservableWWW.Post(Constants.API_LOGOUT, form).Subscribe(
           x =>
           {
               Debug.Log("[*] Logout success");
               manager.SetPanel(PANEL.Login);
           }, // onSuccess
           ex =>
           {
               Debug.Log("[*] Error: " + ex.ToString());
           }); // onError

    }
}
