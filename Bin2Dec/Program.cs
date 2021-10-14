using System;
using System.Linq;

namespace Bin2Dec
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao;
            do
            {
                Console.WriteLine("Escolha a sua opção :");
                Console.WriteLine("\ta - Converter Binário para Decimal");
                Console.WriteLine("\tb - Converter Decimal para Binário");
                Console.WriteLine("\tc - Encerra o programa");
                Console.Write("Informe sua opção:  ");
                opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "a":
                        ConverteBinarioParaDecimal();
                        break;
                    case "b":
                        ConverteDecimalParaBinario();
                        break;
                    case "c":
                        Console.WriteLine("Bye.");
                        break;
                }
                Console.ReadKey();
            } while (opcao != "C" && opcao != "c");
        }
        private static void ConverteDecimalParaBinario()
        {
            Console.WriteLine("Informe o numero decimal a converter");
            string valor = Console.ReadLine();
            string resultado = Conversor.DecimalBinario(valor);
            Console.WriteLine($" O numero {valor} é igual a {resultado} ");
            Console.WriteLine();
        }
        private static void ConverteBinarioParaDecimal()
        {
            Console.WriteLine("Informe o numero binário.");
            string valor = Console.ReadLine();
            int resultado = Conversor.BinarioDecimal(valor);
            Console.WriteLine($" O numero {valor} é igual a {resultado} ");
            Console.WriteLine();
        }
    }
    class Conversor
    {
        public static int BinarioDecimal(string numeroBinario)
        {
            int expoente = 0;
            int numero;
            int soma = 0;
            string numeroInvertido = ReverteString(numeroBinario);
            for (int i = 0; i < numeroInvertido.Length; i++)
            {
                numero = Convert.ToInt32(numeroInvertido.Substring(i, 1));
                soma += numero * (int)Math.Pow(2, expoente);
                expoente++;
            }
            return soma;
        }
        public static string DecimalBinario(string numeroDecimal)
        {
            string valor = "";
            int dividendo = Convert.ToInt32(numeroDecimal);
            if (dividendo == 0 || dividendo == 1)
            {
                return Convert.ToString(dividendo);
            }
            else
            {
                while (dividendo > 0)
                {
                    valor += Convert.ToString(dividendo % 2);
                    dividendo = dividendo / 2;
                }
                return ReverteString(valor);
            }
        }
        public static string ReverteString(string str)
        {
            return new string(str.Reverse().ToArray());
        }
    }
}

