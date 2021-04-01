using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao 
{ 
    class Program 
    { 
        static void Main(string[] args) 
        {
            var enderecoArquivo = @"..\..\contas.txt";

            var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Open);

            //É um array que guarda as informações de Bytes temporarias 
            var buffer = new byte[1024]; //1024 = 1 KB
            var numeroDeBytesLidos = -1;

            //Ele ta conseguindo ler um arq de 24kbts utilizando apenas um array de 1kbts
            while(numeroDeBytesLidos != 0)
            {
                numeroDeBytesLidos = fluxoArquivo.Read(buffer, 0, 1024);
                EscreverBuffer(buffer);
            }

            Console.ReadLine();
        }

        public static void EscreverBuffer(byte[] buffer)
        {
            var utf8 = new UTF8Encoding();
           // var utf8 = Encoding.Default;

            var texto = utf8.GetString(buffer);
            Console.Write(texto);


            //foreach (var myBite in buffer)
            //{
            //    Console.Write(myBite);
            //    Console.Write(" ");
            //}

        }
    }
} 
 