using System;
using System.Collections.Generic;
[Serializable]
public class CapturaDados
{
    public string emailJogador;
    public string sexo;
    public string faixaEtaria;
    public string dataHora;
    public int fasesDesbloqueadas = 0;
    public float tempoTotalJogado = 0;
    public List<CapturaFase> capturaFases = new List<CapturaFase>();

    public void inicializarFase(int numFase)
    {
        CapturaFase capturaFase = new CapturaFase();
        capturaFase.fase = numFase;
        capturaFase.status = "bloqueado";
        capturaFase.quantVezesTentadas = 0;
        capturaFases.Add(capturaFase);        
    }

    public void incrementaTentativas(int fase)
    {
        for(int i = 0; i < capturaFases.Count; i++)
        {
            if(capturaFases[i].fase == fase)
            {
                capturaFases[i].quantVezesTentadas += 1;
                break;  
            }

        }
    }

    public void adicionarNovaSessao(int faseAtual, List<String> plataformasPuladas, string resultado, float tempoemFase)
    {
        // Busca a fase para adicionar a sessao
        for (int i = 0; i < capturaFases.Count; i++)
        {
            if (capturaFases[i].fase == faseAtual)
            {
                CapturaSecoes capturaSecoes = new CapturaSecoes();
                capturaSecoes.resultadoTrajetoria = resultado;
                capturaSecoes.trajetoria = plataformasPuladas;
                capturaSecoes.tempoEmFase = tempoemFase;
                capturaFases[i].capturaSecoes.Add(capturaSecoes);
            }
        }
    }

    public void adicionarNovaSessao(int faseAtual, List<String> plataformasPuladas, string resultado, float tempoemFase, String motivoDerrota)
    {
        // Busca a fase para adicionar a sessao
        for(int i = 0; i < capturaFases.Count; i++)
        {
            if(capturaFases[i].fase == faseAtual)
            {
                CapturaSecoes capturaSecoes = new CapturaSecoes();
                capturaSecoes.resultadoTrajetoria = resultado;
                capturaSecoes.trajetoria = plataformasPuladas;
                capturaSecoes.tempoEmFase = tempoemFase;
                capturaSecoes.motivoDerrota = motivoDerrota;
                capturaFases[i].capturaSecoes.Add(capturaSecoes);
            }
        }
    }
}
