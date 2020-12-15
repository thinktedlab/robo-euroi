using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlar_hud_menu : MonoBehaviour
{
    public Toggle toque;
    public Toggle som;
    public GameObject configsMenu;
    void Start()
    {
        this.verificaToggles();
    }

    public void active()
    {
        configsMenu.active = !configsMenu.active;
    }
    void verificaToggles()
    {
        if (PlayerPrefs.GetInt("som") == 0)
        {
            som.isOn = false;
        }
        else
        {
            som.isOn = true;
        }
        if (PlayerPrefs.GetInt("toque") == 0)
        {
            toque.isOn = false;
        }
        else
        {
            toque.isOn = true;
        }

    }
    public void modificarAtivacaoSom()
    {
        if (som.isOn)
        {
            PlayerPrefs.SetInt("som", 1);
        }
        else
        {
            PlayerPrefs.SetInt("som", 0);
        }
    }
    public void modificarAtivacaoToque()
    {
        if (toque.isOn)
        {
            PlayerPrefs.SetInt("toque", 1);
        }
        else
        {
            PlayerPrefs.SetInt("toque", 0);
        }
    }
}
