namespace MonitXMLServer.Modells
{
    public class NotaDTO
    {
        public int Origem { get; set; }

        public string OrigemNome { get; set; }

        public int Destino { get; set; }

        public string DestinoNome { get; set; }

        public int Data { get; set; }

        public int Agenda { get; set; }

        public string AgendaNome { get; set; }

        public int Nota { get; set; }

        public string Serie { get; set; }

        public string ChaveNfe { get; set; }
    }
}
