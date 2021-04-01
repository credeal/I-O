
using System;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void CriarArquivo()
        {
            var enderecoArquivo = @"..\..\contasExportadas.csv";

            using (var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Create))
            {
                var contaComString = "456,7895,4785.40, Felipe Santos";
                var enconding = Encoding.UTF8;

                var bytes = enconding.GetBytes(contaComString);
                fluxoArquivo.Write(bytes, 0, bytes.Length);
            }
        }

        static void CriarArquivoComWrite()
        {
            var enderecoArquivo = @"..\..\contasExportadas.csv";
            
             /* A diferença entre Create e CreateNew: no primeiro caso, é apagado o arquivo existente e criado
             * um outro. Já em CreateNew, é feita a verificação da existência do arquivo, e se ele já existe, 
             * será lançada uma exceção.
             */


            using (var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoArquivo))
            {
                escritor.Write("456,65465,456.0,Julio Santos");
            }
        }

        static void TesteEscritaFlush()
        {
            var enderecoArquivo = @"..\..\teste.txt";

            using (var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoArquivo))
            {
                for (int i = 0; i < 15; i++)
                {
                    escritor.WriteLine($"Linha{i}");
                    escritor.Flush(); //Despeja o buffer para o stream
                    //sem o fluxo ele não escreve no HD

                    Console.WriteLine($"Linha{i} fo escrita no arquivo.");
                    Console.ReadLine();
                }
            }
        }
    }
}
 