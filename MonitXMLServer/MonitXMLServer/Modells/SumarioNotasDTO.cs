namespace MonitXMLServer.Modells
{
    public class SumarioNotasDTO
    {
        public SumarioNotasDTO()
        { }

        public SumarioNotasDTO(string pStatus, int pRegistros)
        {
            this.Label = pStatus;
            this.Data = pRegistros;
        }

        public string Label { get; set; }

        public int Data { get; set; }
    }
}
