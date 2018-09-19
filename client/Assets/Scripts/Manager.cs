using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public enum PANEL
{
    Download,
    Upload,
    Login,
    Register,
    Menu
}
public class Manager : MonoBehaviour
{
    public DownloadPanel downloadPanel;
    public UploadPanel uploadPanel;
    public LoginPanel loginPanel;
    public RegisterPanel registerPanel;
    public MenuPanel menuPanel;

    public Image transparent;
    private bool isLock;
    private void Start()
    {
    /*
        Debug.Log("Start download" + @"https://pearl-rest-api.s3.amazonaws.com/test1/2018-09-19_100901_file.png");
        ObservableWWW.GetAndGetBytes(@"https://pearl-rest-api.s3.amazonaws.com/test1/2018-09-19_100901_file.png")
               .Subscribe(
                   x =>
                   {
                       System.IO.File.WriteAllBytes(System.IO.Path.Combine(Application.persistentDataPath, "comment.png"), x);

                       Debug.Log("download success");

                   }, // onSuccess
                   ex =>
                   {
                       Debug.Log(ex.ToString());



                   }); // onError
                   */
    }
    public void SetPanel(PANEL panel)
    {
        downloadPanel.gameObject.SetActive(panel == PANEL.Download);
        uploadPanel.gameObject.SetActive(panel == PANEL.Upload);

        loginPanel.gameObject.SetActive(panel == PANEL.Login);
        registerPanel.gameObject.SetActive(panel == PANEL.Register);
        menuPanel.gameObject.SetActive(panel == PANEL.Menu);
    }

    public bool Lock
    {
        get
        {
            return isLock;
        }
        set
        {
            isLock = value;
            if (value)
            {

                transform.gameObject.SetActive(true);
            }
            else
            {
                transform.gameObject.SetActive(false);
            }
        }
    }

}

