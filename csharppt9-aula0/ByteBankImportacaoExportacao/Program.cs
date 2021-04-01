using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao 
{ 
    partial class Program 
    { 
        static void Main(string[] args) 
        {
            var enderecoArquivo = @"..\..\contas.txt";
            
            using(var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
            using(var leitor = new StreamReader(fluxoArquivo))
            {
               while (!leitor.EndOfStream)
               {
                   var linha = leitor.ReadLine();
                   Console.WriteLine(linha);
               }
            }                
            
            Console.ReadLine();
        }

      


    }
} 
 