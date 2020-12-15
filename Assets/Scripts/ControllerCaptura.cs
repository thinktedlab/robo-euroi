using System.Net.Mail;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using UnityEngine;
using System;

public class ControllerCaptura : MonoBehaviour
{

    public static int contRelatorio = 0;
    public static CapturaDados captura = new CapturaDados(); //Variavel que vai controlar o objeto captura

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        for (int i = 0; i < 13; i++)
        {
            // Populo meu json com a quantidade de fases disponiveis
            captura.inicializarFase(i + 1);
        }
    }

    public void SendEmail(String path)
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        SmtpServer.Timeout = 10000;
        SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        SmtpServer.UseDefaultCredentials = false;
        SmtpServer.Port = 587;

        mail.From = new MailAddress("croboeuroii@gmail.com");
        mail.To.Add(new MailAddress("croboeuroii@gmail.com"));

        mail.Subject = "Dados Analise " + DateTime.Now.ToString();
        mail.Body = "Dados Euroi";

        System.Net.Mail.Attachment attachment;
        attachment = new System.Net.Mail.Attachment(path);

        mail.Attachments.Add(attachment);


        SmtpServer.Credentials = new System.Net.NetworkCredential("croboeuroii@gmail.com", "roboeuroi2020") as ICredentialsByHost; SmtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };

        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpServer.Send(mail);
    }
    // Solução temporaria ----------------------------
    public void converterParaJson()
    {
        // Converte para json minha classe e envio direto pro meu google drive para salvar os arquivos
        captura.tempoTotalJogado = MusicaForaDoJogo.tempoTotalEmJogo;

        string json = JsonUtility.ToJson(captura);
        Teste teste = new Teste();
        string json2 = JsonUtility.ToJson(teste);

        Debug.Log(json2);

        string nameFile = "arquivoAnaliseGerado"+contRelatorio.ToString()+".txt";
        string path = Application.persistentDataPath + "/" + nameFile;
     
        File.WriteAllText(path, json);
     
        SendEmail(path);

        contRelatorio++;

        //var file = new UnityGoogleDrive.Data.File { Parents = new List<string>(new string[] { "1cPjGuxKyHzpNM_pvMBG7TQLQhXc1z2bs" }), Name = DateTime.Now + ".txt", Content = File.ReadAllBytes(path) };

        //GoogleDriveFiles.Create(file).Send();
    }
}