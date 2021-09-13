using System;

namespace MonitXMLServer.Modells
{
    public class AcompanhamentoDTO
    {
        public AcompanhamentoDTO()
        {

        }

        public AcompanhamentoDTO(int pOrigem, string pRazaoSocial, int pDestino, int pNota, string pSerie, string pChaveNfe, string pSituacao)
        {
            this.Origem = pOrigem;
            this.RazaoSocial = pRazaoSocial;
            this.Destino = pDestino;
            this.Nota = pNota;
            this.Serie = pSerie;
            this.ChaveNfe = pChaveNfe;
            this.Situacao = pSituacao;

            Cataloga();
        }

        public int Origem { get; set; }

        public string RazaoSocial { get; set; }

        public int Destino { get; set; }

        public int Nota { get; set; }

        public string Serie { get; set; }

        public string ChaveNfe { get; set; }

        public string Situacao { get; set; }

        public void Cataloga()
        {
            SumarioErrosDTO sumErroDto;
            var rng = new Random();
            int qtdErros = 0;
            int codErro = 0;
            bool blnExiste = false;

            if (Situacao.ToUpper().Equals("IMPORTADO"))
            {
                Dados.qtdImportado++;
            }
            else
            {
                Dados.qtdNaoImportado++;

                qtdErros = rng.Next(1, 3);

                for (int i = 0; i <= qtdErros; i++)
                {
                    blnExiste = false;
                    codErro = rng.Next(1, 7);
                    sumErroDto = new SumarioErrosDTO("E" + codErro.ToString(), 1);

                    foreach (SumarioErrosDTO item in Dados.lstSumarioErros)
                    {
                        if (item.Label.Equals(sumErroDto.Label))
                        {
                            item.Data++;
                            blnExiste = true;
                        }
                    }

                    if (blnExiste == false)
                    {
                        Dados.lstSumarioErros.Add(sumErroDto);
                    }
                }
            }
        }
    }
}
