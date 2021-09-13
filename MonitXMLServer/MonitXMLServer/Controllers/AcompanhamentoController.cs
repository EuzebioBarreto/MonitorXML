using Microsoft.AspNetCore.Mvc;
using MonitXMLServer.Modells;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace MonitXMLServer.Controllers
{
    [ApiController]
    [Route("Acomp")]
    public class AcompanhamentoController : ControllerBase
    {
        [HttpGet]
        [Route("Notas")]
        public List<AcompanhamentoDTO> GetNotas()
        {
            var rng = new Random();
            int tam = 0;
            int indice = 0;

            AcompanhamentoDTO acompDto;
            List<AcompanhamentoDTO> lstAcompTmp = new List<AcompanhamentoDTO>();

            if (Dados.lstAcompanhamento.Count == 0)
            {
                try
                {
                    OracleConnection conn = new OracleConnection();
                    conn.ConnectionString = Dados.connStr;
                    OracleCommand cmd = conn.CreateCommand();

                    try
                    {
                        conn.Open();
                        cmd.BindByName = true;
                        string sql;

                        sql = @"SELECT NFI_ORIGEM || DAC(NFI_ORIGEM) ORIGEM, 
                                    ORIG.TIP_RAZAO_SOCIAL ORIGEM_NOME,
                                    NFI_DESTINO || DAC(NFI_DESTINO) DESTINO, 
                                    DEST.TIP_RAZAO_SOCIAL DESTINO_NOME, 
                                    NFI_DATA_AGENDA DATA, 
                                    NFI_AGENDA AGENDA, 
                                    TRIM(TAB_CONTEUDO) AGENDA_NOME, 
                                    NFI_NOTA NOTA, 
                                    NFI_SERIE SERIE, 
                                    NFI_CHAVE_NFE CHAVE
                                FROM AG1LGNFI, AG2DETNT, AA3CITEM, AA2CTABE, AA2CTIPO ORIG, AA2CTIPO DEST 
                                WHERE REN_DISTRIB    = NFI_ORIGEM
                                AND REN_DESTINO      = NFI_DESTINO || DAC(NFI_DESTINO)
                                AND REN_DTA_AGENDA   = NFI_DATA_AGENDA
                                AND REN_TPO_AGENDA   = NFI_AGENDA
                                AND REN_NOTA         = NFI_NOTA
                                AND REN_SERIE        = NFI_SERIE
                                AND GIT_COD_ITEM || GIT_DIGITO = TO_NUMBER(SUBSTR(REN_ITEM, -8))
                                AND ORIG.TIP_CODIGO  = NFI_ORIGEM
                                AND DEST.TIP_CODIGO  = NFI_DESTINO
                                AND TAB_CODIGO       = 14
                                AND TRIM(TAB_ACESSO) = TO_CHAR(NFI_AGENDA, 'fm000')
                                AND trim(NFI_CHAVE_NFE) is not null";

                        cmd.CommandText = sql;

                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            acompDto = new AcompanhamentoDTO();
                            acompDto.Origem = int.Parse(reader.GetValue("ORIGEM").ToString());
                            acompDto.RazaoSocial = reader.GetValue("ORIGEM_NOME").ToString();
                            acompDto.Destino = int.Parse(reader.GetValue("DESTINO").ToString());
                            acompDto.Nota = int.Parse(reader.GetValue("NOTA").ToString()); ;
                            acompDto.Serie = reader.GetValue("SERIE").ToString();
                            acompDto.ChaveNfe = reader.GetValue("CHAVE").ToString();
                            acompDto.Situacao = Dados.Situacao[rng.Next(0, 3)];

                            Dados.lstAcompanhamento.Add(acompDto);
                        }

                        reader.Dispose();
                        cmd.Dispose();
                        conn.Close();
                        conn.Dispose();

                    }
                    catch (Exception ex)
                    {

                    }
                }
                catch (Exception ex)
                {

                }
            }

            //retorna apenas 10 registro como teste para a api
            tam = Dados.lstAcompanhamento.Count;
            for (int i = 0; i < 5; i++)
            {
                indice = rng.Next(0, tam);
                Dados.lstAcompanhamento[indice].Cataloga();
                lstAcompTmp.Add(Dados.lstAcompanhamento[indice]);
            }

            return lstAcompTmp;
        }

        [HttpGet]
        [Route("SumarioNotas")]
        public List<SumarioNotasDTO> GetSumarioNotas()
        {
            List<SumarioNotasDTO> lstSumarioNotas = new List<SumarioNotasDTO>();
            SumarioNotasDTO sumarioNotas;

            sumarioNotas = new SumarioNotasDTO("Importados", Dados.qtdImportado);
            lstSumarioNotas.Add(sumarioNotas);

            sumarioNotas = new SumarioNotasDTO("Não Importados", Dados.qtdNaoImportado);
            lstSumarioNotas.Add(sumarioNotas);

            return lstSumarioNotas;
        }

        [HttpGet]
        [Route("SumarioErros")]
        public List<SumarioErrosDTO> GetSumarioErros()
        {
            return Dados.lstSumarioErros;
        }
    }
}
