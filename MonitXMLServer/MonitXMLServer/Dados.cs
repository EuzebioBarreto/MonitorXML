using MonitXMLServer.Modells;
using System.Collections.Generic;

namespace MonitXMLServer
{
    public static class Dados
    {
        public static List<SumarioErrosDTO> lstSumarioErros = new List<SumarioErrosDTO>();

        public static List<AcompanhamentoDTO> lstAcompanhamento = new List<AcompanhamentoDTO>();

        public static List<ErroDTO> lstErros = new List<ErroDTO>();

        public static readonly string[] Situacao = {
            "PROCESSANDO", "IMPORTADO", "NÃO IMPORTADO"
        };

        public static string connStr = "User Id=CLIENTES_GIASSI_DE01;Password=CLIENTES_GIASSI_DE01;Data Source=10.172.212.145:1521/orcl";

        public static int qtdImportado { get; set; }

        public static int qtdNaoImportado { get; set; }

        public static void CarregarListaErros()
        {
            ErroDTO erro;

            erro = new ErroDTO("E1", "Erro na carga do arquivo XML e/ou XML inválido");
            lstErros.Add(erro);
            erro = new ErroDTO("E2", "A Situação da NFe está inconsistente para ser importada");
            lstErros.Add(erro);
            erro = new ErroDTO("E3", "CNPJ Destinatário não cadastrado");
            lstErros.Add(erro);
            erro = new ErroDTO("E4", "Filial da NF inexistente ou Diferente de L ou D");
            lstErros.Add(erro);
            erro = new ErroDTO("E5", "Filial não cadastrada");
            lstErros.Add(erro);
            erro = new ErroDTO("E6", "CNPJ/CPF Emitente não cadastrado");
            lstErros.Add(erro);
            erro = new ErroDTO("E7", "Fornecedor não cadastrado/Fora de Linha/não permitido");
            lstErros.Add(erro);
            erro = new ErroDTO("E8", "Não é possivel importar Nota Fiscal de Entrada de Fornecedor");
            lstErros.Add(erro);
            erro = new ErroDTO("E9", "Nota Fiscal já importada");
            lstErros.Add(erro);
            erro = new ErroDTO("E10", "Empresa não cadastrada no Cadastro de Empresas");
            lstErros.Add(erro);
            erro = new ErroDTO("E11", "Parâmetro 002, Acesso AGENDAEDI não cadastrado/cadastrado incorretamente");
            lstErros.Add(erro);
            erro = new ErroDTO("E12", "Agenda não cadastrada para o CFOP");
            lstErros.Add(erro);
            erro = new ErroDTO("E13", "Problemas ao Atualizar Nota Fiscal no Banco de Dados (InfraEstrutura)");
            lstErros.Add(erro);
            erro = new ErroDTO("E14", "Referência não cadastrada");
            lstErros.Add(erro);
            erro = new ErroDTO("E15", "EAN13 ou DUN14 não cadastrado");
            lstErros.Add(erro);
            erro = new ErroDTO("E16", "Tabela Fiscal não cadastrada");
            lstErros.Add(erro);
            erro = new ErroDTO("E17", "Conteúdo do parâmetro 003-DIRXMLNFE inválido");
            lstErros.Add(erro);
            erro = new ErroDTO("E18", "Erro na criação dos diretórios para a importação XML da NFe");
            lstErros.Add(erro);
            erro = new ErroDTO("E19", "Documento de EDI não Cadastrado");
            lstErros.Add(erro);
            erro = new ErroDTO("E20", "Arquivo com erro TAG de Validação (SEFAZ)");
            lstErros.Add(erro);
            erro = new ErroDTO("E21", "Faturamento em unidade não confere confere com Tipo de Embalagem CX");
            lstErros.Add(erro);
            erro = new ErroDTO("E22", "Data de emissão inferior a data parametrizada para importação");
            lstErros.Add(erro);
            erro = new ErroDTO("E23", "Produto duplicado no XML");
            lstErros.Add(erro);
            erro = new ErroDTO("E24", "XML Cancelado apos NF ser Atualizada");
            lstErros.Add(erro);
            erro = new ErroDTO("E25", "% ICMS Fornecedor Simples Nacional diferente % XML");
            lstErros.Add(erro);
            erro = new ErroDTO("E26", "Fornecedor não permite importação de notas XML");
            lstErros.Add(erro);
            erro = new ErroDTO("E27", "Filial não cadastrada para importação de notas XML");
            lstErros.Add(erro);
            erro = new ErroDTO("E28", "Produto inválido para recebimento de NF via XML");
            lstErros.Add(erro);
            erro = new ErroDTO("E29", "Transportadora não cadastrada");
            lstErros.Add(erro);
            erro = new ErroDTO("E30", "Produto fora de linha");
            lstErros.Add(erro);
            erro = new ErroDTO("E31", "Produto não pertence a linha da filial");
            lstErros.Add(erro);
            erro = new ErroDTO("E32", "Problema na validação do NCM");
            lstErros.Add(erro);
            erro = new ErroDTO("E33", "Problema na validação do CEST");
            lstErros.Add(erro);
            erro = new ErroDTO("E34", "Simples Nacional: informação do Fornecedor no XML difere do Cadastro");
            lstErros.Add(erro);
            erro = new ErroDTO("E35", "Pedido Enviado Antes da Data Prevista para Entrega");
            lstErros.Add(erro);
            erro = new ErroDTO("E36", "Problema na validação da Origem/Procedencia");
            lstErros.Add(erro);
        }
    }
}
