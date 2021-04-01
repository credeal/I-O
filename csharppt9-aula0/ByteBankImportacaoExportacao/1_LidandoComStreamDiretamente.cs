
using System;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    //Partial = Fala que essa classe programa é uma classe parcial da outra program
    //eu Basicamente divi a classe em dois arquivos 
    partial class Program
    {
        public static void LidandoComFileStreamDiretamente()
        {
            var enderecoArquivo = @"..\..\contas.txt";

            using (var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
            {
                //É um array que guarda as informações de Bytes temporarias 
                var buffer = new byte[1024]; //1024 = 1 KB
                var numeroDeBytesLidos = -1;

                //Ele ta conseguindo ler um arq de 24kbts utilizando apenas um array de 1kbts
                while (numeroDeBytesLidos != 0)
                {
                    numeroDeBytesLidos = fluxoArquivo.Read(buffer, 0, 1024);
                    EscreverBuffer(buffer, numeroDeBytesLidos);
                    Console.Write($"Nº de Bytes Lidos: {numeroDeBytesLidos}");

                }
            }
        }

        public static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            var utf8 = new UTF8Encoding();
            // var utf8 = Encoding.Default;

            var texto = utf8.GetString(buffer, 0, bytesLidos);
            Console.Write(texto);


            //foreach (var myBite in buffer)
            //{
            //    Console.Write(myBite);
            //    Console.Write(" ");
            //}

        }

        public static void MetodoClose()
        {
            var enderecoArquivo = @"..\..\contas.txt";

            var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Open);

            try
            {

            }
            catch (IOException ex)
            {
                throw new IOException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (fluxoArquivo != null)
                    fluxoArquivo.Close();//Indicar para o SO que pode fechar o arquivo
            }

        }
    }
}