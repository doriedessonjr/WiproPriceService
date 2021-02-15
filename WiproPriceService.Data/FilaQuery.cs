using System;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using WiproPriceService.Model;

namespace WiproPriceService.Data
{
    public class FilaQuery
    {
        public static bool FilaExistsOnDB(string url_Servico, out Fila filaOutput)
        {
            HttpWebRequest Request;
            WebResponse Response = null;
            StreamReader ReaderStream = null;
            StreamWriter StreamWriter = null;
            string resultGet = default;
            filaOutput = new Fila();

            try
            {
                Request = (HttpWebRequest)WebRequest.Create(url_Servico);
                Request.Method = "GET";
                Request.ContentType = "application/json";
                Request.Proxy = null;

                //Enviando o chamado do WS e retornando o resultado
                using (Response = Request.GetResponse())
                {
                    ReaderStream = new StreamReader(Response.GetResponseStream());
                    resultGet = ReaderStream.ReadToEnd();
                }

                #region Deserializa apenas a estrutura "Resultado" do Json retornado do serviço
                JObject jObject = JObject.Parse(resultGet);

                JValue servicoRetornoExecutouComSucesso = (JValue)jObject["ExecutouComSucesso"];
                JArray servicoResultadoArray = (JArray)jObject["Resultado"];

                IList<Fila> FilaQuery = servicoResultadoArray.Select(p => new Fila
                {
                    Moeda = (string)p["Moeda"],
                    DataInicio = (DateTime)p["DataInicio"],
                    DataFim = (DateTime)p["DataFim"],
                }).ToList();

                #endregion

                if ((bool)servicoRetornoExecutouComSucesso == true) //Pesquisa executada com sucesso?
                {
                    if (FilaQuery.Count > 0)
                    {
                        filaOutput.Moeda = FilaQuery[0].Moeda;
                        filaOutput.DataInicio = FilaQuery[0].DataInicio;
                        filaOutput.DataFim = FilaQuery[0].DataFim;

                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exp)
            {
                return false;
            }
            finally
            {
                try { Request = null; } catch { };
                try { if (Response != null) Response.Close(); } catch { };
                try { if (ReaderStream != null) ReaderStream.Close(); } catch { };
                try { if (StreamWriter != null) StreamWriter.Close(); } catch { };
            }
        }
    }
}
