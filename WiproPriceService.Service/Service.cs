using System.Configuration;
using WiproPriceService.Business;
using WiproPriceService.Data;
using WiproPriceService.Model;

namespace WiproPriceService.Service
{
    class Service
    {
        static void Main(string[] args)
        {
            Fila fila = new Fila();

            //Carregando variáveis do AppConfig
            string urlGetFilaLastId = ConfigurationManager.AppSettings["URL_GETFILALASTID"];
            string dirDadosCotacaoCsv = ConfigurationManager.AppSettings["DIR_DADOSCOTACAOCSV"];
            string dirDadosMoedaCsv = ConfigurationManager.AppSettings["DIR_DADOSMOEDACSV"];

            if (FilaQuery.FilaExistsOnDB(urlGetFilaLastId, out fila)) //Consultando se existe item na fila
            {
                var filaCsvs = CsvUtil.RetornaListaMoedasCSV(dirDadosMoedaCsv, fila); //Retornando a Lista de moedas e datas filtradas pelo intervalo de datas do item da fila
                
                CsvUtil.GeraArquivoCotacaoCsv(dirDadosCotacaoCsv, filaCsvs); //Retornando o valor da cotação para a moeda e data e gerando o arquivo CSV de saída
            }
        }
    }
}
