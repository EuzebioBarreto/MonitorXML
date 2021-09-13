namespace MonitXMLServer.Modells
{
    public class ErroDTO
    {
        public ErroDTO() { }

        public ErroDTO(string pCodigo, string pDescricao) 
        {
            this.Codigo = pCodigo;
            this.Descricao = pDescricao;
        }

        public string Codigo { get; set; }

        public string Descricao { get; set; }
    }
}
