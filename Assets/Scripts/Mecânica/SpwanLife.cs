using UnityEngine;

public class SpwanLife : MonoBehaviour
{
    public Transform[] transformVidaSpwan; //Locais que a vida pode ser spawnada
    public GameObject spawNado; //Vai pegar o objeto spawpanado
    public GameObject gameObjVida;  //Objeto que vai ser instanciando - Vida
    int numeroAleatorioPosicaoVida = 0; //Vai receber um numero aleatorio para vida spwanar
    public bool gerarVida = false; //Flag responsavel por verificar a necessidade de gerar vida
    public float contadorDeTempoAntesVida = 0; //Contador de tempo antes da vida ser spwanada
    public float contadorDeTempo = 0; //Contador de tempo de existencia da Vida, até que ela desapareca
    void Update()
    {
        gerarPosicaoAleatoria();
    }

    void gerarPosicaoAleatoria()
    {

        if (gerarVida)
        {
            if(contadorDeTempoAntesVida <= 5)
            {
                contadorDeTempoAntesVida += Time.deltaTime;
            }
            else
            {
                gerarVida = false;
                contadorDeTempoAntesVida = 0;
                if(spawNado!= null)
                {
                    Destroy(spawNado.gameObject);
                }
                numeroAleatorioPosicaoVida = Random.Range(0, 4);
                gameObjVida.GetComponent<EnergiaPositiva>().valueEnergia = 3;
                spawNado = Instantiate(gameObjVida, transformVidaSpwan[numeroAleatorioPosicaoVida].position, gameObjVida.gameObject.transform.rotation);
            }
        }
        else
        {
            if(spawNado == null)
            {
                contadorDeTempo = 0;
                gerarVida = true;
            }
            else
            {
                contadorDeTempo += Time.deltaTime;
                if (contadorDeTempo >= 5)
                {
                    contadorDeTempo = 0;
                    gerarVida = true;  
                }
            }
        }
    }
}
