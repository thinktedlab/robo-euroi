using System.Collections.Generic;
using System;
[Serializable]
public class CapturaFase
{
    public int fase;
    public string status;
    public int quantVezesTentadas;
    public List<CapturaSecoes> capturaSecoes = new List<CapturaSecoes>();
}
