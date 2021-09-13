using Microsoft.AspNetCore.Mvc;
using MonitXMLServer.Modells;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace MonitXMLServer.Controllers
{
    [ApiController]
    [Route("ConsultaNota")]
    public class NotaController : ControllerBase
    {
        [HttpPost]
        [Route("Objeto")]
        public NotaDTO GetNota(NotaDTO pNota)
        {
            NotaDTO nota = new NotaDTO();

            try
            {
                if (!pNota.ChaveNfe.Trim().Equals(""))
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
                                FROM AG1LGNFI, 
                                    AA2CTABE, 
                                    AA2CTIPO ORIG, 
                                    AA2CTIPO DEST
                                WHERE ORIG.TIP_CODIGO = NFI_ORIGEM
                                AND DEST.TIP_CODIGO   = NFI_DESTINO
                                AND TAB_CODIGO        = 14
                                AND TRIM(TAB_ACESSO)  = TO_CHAR(NFI_AGENDA, 'fm000')
                                AND NFI_CHAVE_NFE     = :chaveNfe";

                        cmd.CommandText = sql;
                        cmd.Parameters.Add("chaveNfe", OracleDbType.Varchar2, pNota.ChaveNfe, ParameterDirection.Input);

                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            nota.Origem = int.Parse(reader.GetValue("ORIGEM").ToString());
                            nota.OrigemNome = reader.GetValue("ORIGEM_NOME").ToString();
                            nota.Destino = int.Parse(reader.GetValue("DESTINO").ToString());
                            nota.DestinoNome = reader.GetValue("DESTINO_NOME").ToString();
                            nota.Data = int.Parse(reader.GetValue("DATA").ToString()); ;
                            nota.Agenda = int.Parse(reader.GetValue("AGENDA").ToString()); ;
                            nota.AgendaNome = reader.GetValue("AGENDA_NOME").ToString();
                            nota.Nota = int.Parse(reader.GetValue("NOTA").ToString()); ;
                            nota.Serie = reader.GetValue("SERIE").ToString();
                            nota.ChaveNfe = reader.GetValue("CHAVE").ToString();
                        }

                        reader.Dispose();
                        cmd.Dispose();
                        conn.Close();
                        conn.Dispose();

                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return nota;
        }

        [HttpGet]
        [Route("ChaveNFe")]
        public NotaDTO GetNota(string ChaveNfe)
        {
            NotaDTO nota = new NotaDTO();

            try
            {
                if (!ChaveNfe.Trim().Equals(""))
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
                                FROM AG1LGNFI, 
                                    AA2CTABE, 
                                    AA2CTIPO ORIG, 
                                    AA2CTIPO DEST
                                WHERE ORIG.TIP_CODIGO = NFI_ORIGEM
                                AND DEST.TIP_CODIGO   = NFI_DESTINO
                                AND TAB_CODIGO        = 14
                                AND TRIM(TAB_ACESSO)  = TO_CHAR(NFI_AGENDA, 'fm000')
                                AND NFI_CHAVE_NFE     = :chaveNfe";

                        cmd.CommandText = sql;
                        cmd.Parameters.Add("chaveNfe", OracleDbType.Varchar2, ChaveNfe, ParameterDirection.Input);

                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            nota.Origem = int.Parse(reader.GetValue("ORIGEM").ToString());
                            nota.OrigemNome = reader.GetValue("ORIGEM_NOME").ToString();
                            nota.Destino = int.Parse(reader.GetValue("DESTINO").ToString());
                            nota.DestinoNome = reader.GetValue("DESTINO_NOME").ToString();
                            nota.Data = int.Parse(reader.GetValue("DATA").ToString()); ;
                            nota.Agenda = int.Parse(reader.GetValue("AGENDA").ToString()); ;
                            nota.AgendaNome = reader.GetValue("AGENDA_NOME").ToString();
                            nota.Nota = int.Parse(reader.GetValue("NOTA").ToString()); ;
                            nota.Serie = reader.GetValue("SERIE").ToString();
                            nota.ChaveNfe = reader.GetValue("CHAVE").ToString();
                        }

                        reader.Dispose();
                        cmd.Dispose();
                        conn.Close();
                        conn.Dispose();

                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return nota;
        }

        [HttpGet]
        [Route("ItensChaveNFe")]
        public List<ItemDTO> GetItens(string ChaveNfe)
        {
            List<ItemDTO> lstItensDto = new List<ItemDTO>();
            ItemDTO item;

            try
            {
                if (!ChaveNfe.Trim().Equals(""))
                {
                    OracleConnection conn = new OracleConnection();
                    conn.ConnectionString = Dados.connStr;
                    OracleCommand cmd = conn.CreateCommand();

                    try
                    {
                        conn.Open();
                        cmd.BindByName = true;
                        string sql;

                        sql = @"SELECT GIT_COD_ITEM || GIT_DIGITO CODIGO, 
                                    GIT_DESCRICAO DESCRICAO, 
                                    REN_TPO_EMB EMBALAGEM, 
                                    REN_EMB QTD_EMBALAGEM, 
                                    REN_CUS_UN CUSTO, 
                                    REN_QTD_FAT FATURADO
                                FROM AG1LGNFI, 
                                    AG2DETNT, 
                                    AA3CITEM
                                WHERE REN_DISTRIB  = NFI_ORIGEM
                                AND REN_DESTINO    = NFI_DESTINO || DAC(NFI_DESTINO)
                                AND REN_DTA_AGENDA = NFI_DATA_AGENDA
                                AND REN_TPO_AGENDA = NFI_AGENDA
                                AND REN_NOTA       = NFI_NOTA
                                AND REN_SERIE      = NFI_SERIE
                                AND GIT_COD_ITEM || GIT_DIGITO = TO_NUMBER(SUBSTR(REN_ITEM, -8))
                                AND NFI_CHAVE_NFE  = :chaveNfe";

                        cmd.CommandText = sql;
                        cmd.Parameters.Add("chaveNfe", OracleDbType.Varchar2, ChaveNfe, ParameterDirection.Input);

                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            item = new ItemDTO();
                            item.Codigo = int.Parse(reader.GetValue("CODIGO").ToString());
                            item.Descricao = reader.GetValue("DESCRICAO").ToString();
                            item.Embalagem = reader.GetValue("EMBALAGEM").ToString();
                            item.QtdEmb = double.Parse(reader.GetValue("QTD_EMBALAGEM").ToString());
                            item.Custo = double.Parse(reader.GetValue("CUSTO").ToString());
                            item.Faturado = double.Parse(reader.GetValue("FATURADO").ToString());

                            lstItensDto.Add(item);
                        }

                        reader.Dispose();
                        cmd.Dispose();
                        conn.Close();
                        conn.Dispose();

                    }
                    catch (Exception ex2)
                    {
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return lstItensDto;
        }
    }
}