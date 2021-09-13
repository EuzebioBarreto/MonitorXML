namespace MonitXMLServer.Modells
{
    public class SumarioErrosDTO
    {
        public SumarioErrosDTO()
        { }

        public SumarioErrosDTO(string pStatus, int pRegistros)
        {
            this.Label = pStatus;
            this.Data = pRegistros;
        }

        public string Label { get; set; }

        public int Data { get; set; }
    }
}
