using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Teste
{
    public int number =1;
    public bool status = false;
    public String message = "Hello";
    public int numTentativas = 1;
    public int numErros = 2;

    public List<String> pathImages = new List<string>(new string[] { "element1", "element2", "element3" });
    public Dictionary<String, bool> alternativas = new Dictionary<string, bool>
    {
        ["one"] = false,
        ["two"] = false,
        ["three"] = false
    };
    public List<bool> respostas = new List<bool>(new bool[] { false,true});

    public static List<Teste> getList()
    {
        List<Teste> listTeste = new List<Teste>();
        for (int i = 0; i < 9; i++)
        {
            Teste teste = new Teste();
            listTeste.Add(teste);
        }
        return listTeste;
    }
}
