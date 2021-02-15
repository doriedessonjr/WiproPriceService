using System.Collections.Generic;
using WiproPriceService.Model;

namespace WiproPriceService.Business
{
    public class DeParaMoedas
    {
        public static MoedaDePara GetLista(string id_Moeda)
        {
            List<MoedaDePara> listaMoedas = new List<MoedaDePara>() {
                new MoedaDePara {ID_MOEDA="AFN",COD_COTACAO=66},
                new MoedaDePara {ID_MOEDA="ALL",COD_COTACAO=49},
                new MoedaDePara {ID_MOEDA="ANG",COD_COTACAO=33},
                new MoedaDePara {ID_MOEDA="ARS",COD_COTACAO=3 },
                new MoedaDePara {ID_MOEDA="AWG",COD_COTACAO=6 },
                new MoedaDePara {ID_MOEDA="BOB",COD_COTACAO=56},
                new MoedaDePara {ID_MOEDA="BYN",COD_COTACAO=64},
                new MoedaDePara {ID_MOEDA="CAD",COD_COTACAO=25},
                new MoedaDePara {ID_MOEDA="CDF",COD_COTACAO=58},
                new MoedaDePara {ID_MOEDA="CLP",COD_COTACAO=16},
                new MoedaDePara {ID_MOEDA="COP",COD_COTACAO=37},
                new MoedaDePara {ID_MOEDA="CRC",COD_COTACAO=52},
                new MoedaDePara {ID_MOEDA="CUP",COD_COTACAO=8 },
                new MoedaDePara {ID_MOEDA="CVE",COD_COTACAO=51},
                new MoedaDePara {ID_MOEDA="CZK",COD_COTACAO=29},
                new MoedaDePara {ID_MOEDA="DJF",COD_COTACAO=36},
                new MoedaDePara {ID_MOEDA="DZD",COD_COTACAO=54},
                new MoedaDePara {ID_MOEDA="EGP",COD_COTACAO=12},
                new MoedaDePara {ID_MOEDA="EUR",COD_COTACAO=20},
                new MoedaDePara {ID_MOEDA="FJD",COD_COTACAO=38},
                new MoedaDePara {ID_MOEDA="GBP",COD_COTACAO=22},
                new MoedaDePara {ID_MOEDA="GEL",COD_COTACAO=48},
                new MoedaDePara {ID_MOEDA="GIP",COD_COTACAO=18},
                new MoedaDePara {ID_MOEDA="HTG",COD_COTACAO=63},
                new MoedaDePara {ID_MOEDA="ILS",COD_COTACAO=40},
                new MoedaDePara {ID_MOEDA="IRR",COD_COTACAO=17},
                new MoedaDePara {ID_MOEDA="ISK",COD_COTACAO=11},
                new MoedaDePara {ID_MOEDA="JPY",COD_COTACAO=9 },
                new MoedaDePara {ID_MOEDA="KES",COD_COTACAO=21},
                new MoedaDePara {ID_MOEDA="KMF",COD_COTACAO=19},
                new MoedaDePara {ID_MOEDA="LBP",COD_COTACAO=42},
                new MoedaDePara {ID_MOEDA="LSL",COD_COTACAO=4 },
                new MoedaDePara {ID_MOEDA="MGA",COD_COTACAO=35},
                new MoedaDePara {ID_MOEDA="MGB",COD_COTACAO=26},
                new MoedaDePara {ID_MOEDA="MMK",COD_COTACAO=69},
                new MoedaDePara {ID_MOEDA="MRO",COD_COTACAO=53},
                new MoedaDePara {ID_MOEDA="MRU",COD_COTACAO=15},
                new MoedaDePara {ID_MOEDA="MUR",COD_COTACAO=7 },
                new MoedaDePara {ID_MOEDA="MXN",COD_COTACAO=41},
                new MoedaDePara {ID_MOEDA="MZN",COD_COTACAO=43},
                new MoedaDePara {ID_MOEDA="NIO",COD_COTACAO=23},
                new MoedaDePara {ID_MOEDA="NOK",COD_COTACAO=62},
                new MoedaDePara {ID_MOEDA="OMR",COD_COTACAO=34},
                new MoedaDePara {ID_MOEDA="PEN",COD_COTACAO=45},
                new MoedaDePara {ID_MOEDA="PGK",COD_COTACAO=2 },
                new MoedaDePara {ID_MOEDA="PHP",COD_COTACAO=24},
                new MoedaDePara {ID_MOEDA="RON",COD_COTACAO=5 },
                new MoedaDePara {ID_MOEDA="SAR",COD_COTACAO=44},
                new MoedaDePara {ID_MOEDA="SBD",COD_COTACAO=32},
                new MoedaDePara {ID_MOEDA="SGD",COD_COTACAO=70},
                new MoedaDePara {ID_MOEDA="SLL",COD_COTACAO=10},
                new MoedaDePara {ID_MOEDA="SOS",COD_COTACAO=61},
                new MoedaDePara {ID_MOEDA="SSP",COD_COTACAO=47},
                new MoedaDePara {ID_MOEDA="SZL",COD_COTACAO=55},
                new MoedaDePara {ID_MOEDA="THB",COD_COTACAO=39},
                new MoedaDePara {ID_MOEDA="TRY",COD_COTACAO=13},
                new MoedaDePara {ID_MOEDA="TTD",COD_COTACAO=67},
                new MoedaDePara {ID_MOEDA="UGX",COD_COTACAO=59},
                new MoedaDePara {ID_MOEDA="USD",COD_COTACAO=1 },
                new MoedaDePara {ID_MOEDA="UYU",COD_COTACAO=46},
                new MoedaDePara {ID_MOEDA="VES",COD_COTACAO=68},
                new MoedaDePara {ID_MOEDA="VUV",COD_COTACAO=57},
                new MoedaDePara {ID_MOEDA="WST",COD_COTACAO=28},
                new MoedaDePara {ID_MOEDA="XAF",COD_COTACAO=30},
                new MoedaDePara {ID_MOEDA="XAU",COD_COTACAO=60},
                new MoedaDePara {ID_MOEDA="XDR",COD_COTACAO=27},
                new MoedaDePara {ID_MOEDA="XOF",COD_COTACAO=14},
                new MoedaDePara {ID_MOEDA="XPF",COD_COTACAO=50},
                new MoedaDePara {ID_MOEDA="ZAR",COD_COTACAO=65},
                new MoedaDePara {ID_MOEDA="ZWL",COD_COTACAO=31}
            };

            return listaMoedas.Find(s => s.ID_MOEDA == id_Moeda);
        }
    }
}
