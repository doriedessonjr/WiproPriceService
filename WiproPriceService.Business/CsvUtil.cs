using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WiproPriceService.Model;

namespace WiproPriceService.Business
{
    public class CsvUtil
    {
        public static List<MoedaCsv> RetornaListaMoedasCSV(string DirMoedaCsv, Fila filaApi)
        {
            List<MoedaCsv> listaMoedasRetorno = new List<MoedaCsv>();

            //Abrindo e lendo o arquivo CSV utilizando o diretório informado no parâmetro
            var listCsv = File.ReadAllLines(DirMoedaCsv)
                    .Select(a => a.Split(';'))
                    .Select(c => new MoedaCsv()
                    {
                        ID_MOEDA = c[0],
                        DATA_REF = c[1]
                    })
                    .ToList();

            //Verificando quais moedas estão dentro do período do item retornado da API
            foreach (var item in listCsv) //Lendo a lista retornada do CSV
            {
                if (item.ID_MOEDA.Trim() == filaApi.Moeda.Trim()) //Verificando se a Moeda é a mesma retornada pela API
                {
                    if (DateTime.Parse(item.DATA_REF) >= filaApi.DataInicio && DateTime.Parse(item.DATA_REF) <= filaApi.DataFim) //Se a data do CSV estiver dentro do período, adiciona na lista para retornar
                    {
                        MoedaCsv moedaRetorno = new MoedaCsv() { ID_MOEDA = item.ID_MOEDA, DATA_REF = item.DATA_REF };
                        listaMoedasRetorno.Add(moedaRetorno);
                    }
                }
            }

            return listaMoedasRetorno;
        }

        public static CotacaoCsv RetornaCotacaoMoeda(string DirCotacaoCsv, string codCotacao, DateTime dataCotacao)
        {
            CotacaoCsv cotacaoRetorno = new CotacaoCsv();
            //Abrindo e lendo o arquivo CSV utilizando o diretório informado no parâmetro
            var listCsv = File.ReadAllLines(DirCotacaoCsv)
                    .Select(a => a.Split(';'))
                    .Select(c => new CotacaoCsv()
                    {
                        VLR_COTACAO = c[0],
                        COD_COTACAO = c[1],
                        DAT_COTACAO = c[2]
                    })
                    .ToList();

            //Verificando quais moedas estão dentro do período do item retornado da API
            foreach (var item in listCsv) //Lendo a lista retornada do CSV
            {
                if (item.COD_COTACAO.Trim() == codCotacao.Trim()) //Verificando se o código da cotação é o mesmo informado no parametro de entrada
                {
                    if (DateTime.Parse(item.DAT_COTACAO) == dataCotacao) //Se a data do CSV for igual à data informada, adiciona na lista para retornar
                    {
                        cotacaoRetorno.COD_COTACAO = item.COD_COTACAO;
                        cotacaoRetorno.DAT_COTACAO = item.DAT_COTACAO;
                        cotacaoRetorno.VLR_COTACAO = item.VLR_COTACAO;
                    }
                }
            }

            return cotacaoRetorno;
        }

        public static void GeraArquivoCotacaoCsv(string DirCotacaoCsv,List<MoedaCsv> moedasCsv)
        {
            DateTime localDate = DateTime.Now;            
            string fileName = "Resultado_" + localDate.ToString("yyyyMMdd_HHmmss");
            List<MoedaCsv> listaOutPut = new List<MoedaCsv>();
            

            foreach (var item in moedasCsv) //Lendo a lista de moedas selecionadas no CSV
            {
                MoedaDePara moedaDePara = DeParaMoedas.GetLista(item.ID_MOEDA); //Resgatando a lista de de/para das moedas

                var cotacaoMoeda = RetornaCotacaoMoeda(DirCotacaoCsv, moedaDePara.COD_COTACAO.ToString(), DateTime.Parse(item.DATA_REF)); //Retornando os dados da cotação da moeda e data informados

                //Adicionando a moeda com data e valor da cotacao para o csv de saída
                MoedaCsv moedaOutPut = new MoedaCsv() { ID_MOEDA = item.ID_MOEDA, DATA_REF = item.DATA_REF, VL_COTACAO = cotacaoMoeda.VLR_COTACAO };
                listaOutPut.Add(moedaOutPut);
            }

            ExportCsv(listaOutPut, fileName);
        }

        static void ExportCsv<T>(List<T> genericList, string fileName)
        {
            var sb = new StringBuilder();
            var basePath = "C:/Temp/";//AppDomain.CurrentDomain.BaseDirectory;
            var finalPath = Path.Combine(basePath, fileName + ".csv");
            var header = "";
            var info = typeof(T).GetProperties();
            if (!File.Exists(finalPath))
            {
                var file = File.Create(finalPath);
                file.Close();
                foreach (var prop in typeof(T).GetProperties())
                {
                    header += prop.Name + "; ";
                }
                header = header.Substring(0, header.Length - 2);
                sb.AppendLine(header);
                TextWriter sw = new StreamWriter(finalPath, true);
                sw.Write(sb.ToString());
                sw.Close();
            }
            foreach (var obj in genericList)
            {
                sb = new StringBuilder();
                var line = "";
                foreach (var prop in info)
                {
                    line += prop.GetValue(obj, null) + "; ";
                }
                line = line.Substring(0, line.Length - 2);
                sb.AppendLine(line);
                TextWriter sw = new StreamWriter(finalPath, true);
                sw.Write(sb.ToString());
                sw.Close();
            }
        }
    }
}
