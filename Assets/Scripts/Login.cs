using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Login : MonoBehaviour
{
    public InputField[] loginInput;
    public InputField[] create_userInput;
    public Button logarButton;
    public Button createUserButton;

    // Start is called before the first frame update
    void Start()
    {

        createUserButton.interactable = false;
        logarButton.interactable = false;
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                Debug.Log("Funcionando");
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }
    public void verificarEntradaSignIn()
    {
        Regex regex_email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex_email.Match(loginInput[0].text.ToString());
        if (match.Success && loginInput[1].text.Length > 5)
        {
            logarButton.interactable = true;
        }
        else
        {
            logarButton.interactable = false;
        }
    }
    public void verificarEntradaSignUp()
    {
        Debug.Log("aqui2");
        Regex regex_email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex_email.Match(create_userInput[0].text.ToString());
        if (match.Success && create_userInput[1].text.Length > 5)
        {
            createUserButton.interactable = true;
            Debug.Log("aqui");
        }
        else
        {
            createUserButton.interactable = false;
        }
    }
    public void RegistrarUsuario()
    {
        var auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.CreateUserWithEmailAndPasswordAsync(create_userInput[0].text, create_userInput[1].text).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }
        });
    }
    public void Logar()
    {
        StartCoroutine(LoginCoroutine());
    }
    IEnumerator LoginCoroutine()
    {
        var auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        var logintask = auth.SignInWithEmailAndPasswordAsync(loginInput[0].text, loginInput[1].text);
        yield return new WaitUntil(predicate: () => logintask.IsCompleted);
        if (logintask.Exception == null)
        {
            Firebase.Analytics.FirebaseAnalytics.LogEvent(
                Firebase.Analytics.FirebaseAnalytics.EventLogin,
                new Firebase.Analytics.Parameter[] {
                    new Firebase.Analytics.Parameter(
                    Firebase.Analytics.FirebaseAnalytics.ParameterMethod, auth.CurrentUser.Email.ToString()),
                }
            );
           
            SceneManager.LoadScene("Menu");
        }
        else
        {
            Debug.LogError(logintask.Exception);
        }

    }
}
