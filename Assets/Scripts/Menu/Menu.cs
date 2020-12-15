using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text text_welcome;
    void Start()
    {

        var auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        if (auth.CurrentUser != null)
            text_welcome.text = "BEM VINDO: " + auth.CurrentUser.Email.ToUpper();
        else
            text_welcome.text = "BEM VINDO: " + "ANONIMO";
    }
    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
    public void signOut()
    {
        var auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.SignOut();
        SceneManager.LoadScene("Login");
    }
}
