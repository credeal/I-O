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



        public static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            var enderecoArquivo = @"..\..\contas.txt";

            using (var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoArquivo, Encoding.UTF8))
            {
                while (!leitor.EndOfStream)
                {
                    var linhaa = leitor.ReadLine();
                    var conta = ConverterStringParaContaCorrente(linhaa);
                    string msg = $"{conta.Titular.Nome} = (Agência: {conta.Agencia} - Número: {conta.Numero})";
                    Console.WriteLine(msg);
                }
            }


            string[] campos = linha.Split(',');
            //csv = separador por ,

            var agencia = Convert.ToInt32(campos[0]);
            var numero = int.Parse(campos[1]);
            var saldo = double.Parse(campos[2].Replace('.', ','));
            var nome = campos[3];

            var titular = new Cliente();
            titular.Nome = nome;

            var resultado = new ContaCorrente(agencia, numero);
            resultado.Depositar(saldo);
            resultado.Titular = titular;

            return resultado;

        }
    }
}
