using System;
using System.Collections.Generic;

namespace Calculadora_IEE754
{
    class Program
    {
        static void Main(string[] args)
        {
            double num, res, res1, res2;
            double numInteiro, numDecimal;
            string binarioInteiro = "", binarioDecimal = "", binarioExpoente = "", binarioFinal = "";
            int cont = 0;

            Console.WriteLine("\n\n\tPADRÃO IEEE4754");

            Console.Write("Digite um valor com inteiro com casas decimais: ");
            num = Convert.ToDouble(Console.ReadLine());

            // ALGORITMO PARA DIVIDIR PARTE INTEIRA DE DECIMAL
            string[] arr = num.ToString().Split(",");
            numInteiro = Convert.ToDouble(arr[0]);
            numDecimal = Convert.ToDouble("0," + arr[1]);

            // Console.WriteLine(arr[0] + " e 0," + arr[1]);

            // CONVERTER NÚMERO INTEIRO EM BINÁRIO
            res = numInteiro;
            do{
                if (res % 2 == 0)
                {
                    res = res / 2;
                    binarioInteiro = "0" + binarioInteiro;
                }
                else
                {
                    res = res / 2;
                    res = res - 0.5;
                    binarioInteiro = "1" + binarioInteiro;
                }
                cont++;
            }while(res > 0);

            Console.WriteLine("Cont: " + cont);
            Console.WriteLine("Binário da parteira inteira: " + binarioInteiro);

            // CONVERTER NÚMERO DECIMAL EM BINÁRIO
            res1 = numDecimal;
            int completarBits = 32 - (cont -1) - 9;
            for(int i = 0; i < completarBits; i++) // FAZER ALGORITMO PRO CONT FICAR CERTO
            {
                res1 = res1 * 2;

                if (res1 > 1)
                {
                    binarioDecimal = binarioDecimal  + "1";
                }
                else
                {
                    binarioDecimal = binarioDecimal + "0";
                }
                if (res1 > 1)
                {
                    res1 = res1 - 1;
                }
            }

            Console.WriteLine("Binário da parteira decimal: " + binarioDecimal);

            int expoente = (cont - 1) + 127;
            res2 = expoente;
            do{
                if (res2 % 2 == 0)
                {
                    res2 = res2 / 2;
                    binarioExpoente = "0" + binarioExpoente;
                }
                else
                {
                    res2 = res2 / 2;
                    res2 = res2 - 0.5;
                    binarioExpoente = "1" + binarioExpoente;
                }
                cont++;
            }while(res2 > 0);

            Console.WriteLine("Expoente: " + expoente);
            Console.WriteLine("Binário expoente: " + binarioExpoente);

            // NORMALIZAÇÂO
            if (num > 0)
            {
                binarioFinal = "0" + binarioExpoente + binarioInteiro.Remove(0, 1) + binarioDecimal;
            }
            else
            {
                binarioFinal = "1" + binarioExpoente + binarioInteiro.Remove(0, 1) + binarioDecimal;
            }

            string aux = binarioFinal;
            Console.WriteLine("Final: " + binarioFinal);
            Console.WriteLine("aux: " + aux.Substring(28, 31));

            // for(int j = 0; j < 8; j++)
            // {
                

            // }
        }
    }
}
