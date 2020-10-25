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

            Console.Write("\tDigite um valor com inteiro com casas decimais: ");
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

            // Console.WriteLine("Cont: " + cont);
            // Console.WriteLine("Binário da parteira inteira: " + binarioInteiro);

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

            // Console.WriteLine("Binário da parteira decimal: " + binarioDecimal);

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

            // Console.WriteLine("Expoente: " + expoente);
            // Console.WriteLine("Binário expoente: " + binarioExpoente);

            // NORMALIZAÇÂO
            if (num > 0)
            {
                binarioFinal = "0" + binarioExpoente + binarioInteiro.Remove(0, 1) + binarioDecimal;
            }
            else
            {
                binarioFinal = "1" + binarioExpoente + binarioInteiro.Remove(0, 1) + binarioDecimal;
            }

            // Console.WriteLine("Final: " + binarioFinal);

            // CONVERTER BINARIO PARA HEXADECIMAL
            string aux = binarioFinal;
            string hex = "";
            for(int j = 0; j < 32; j = j + 4)
            {
                string hexBinario = aux.Substring(j, 4);

                switch (hexBinario)
                {
                    case "0000":
                        hex = hex + "0";
                    break;
                    case "0001":
                        hex = hex + "1";
                    break;
                    case "0010":
                        hex = hex + "2";
                    break;
                    case "0011":
                        hex = hex + "3";
                    break;
                    case "0100":
                        hex = hex + "4";
                    break;
                    case "0101":
                        hex = hex + "5";
                    break;
                    case "0110":
                        hex = hex + "6";
                    break;
                    case "0111":
                        hex = hex + "7";
                    break;
                    case "1000":
                        hex = hex + "8";
                    break;
                    case "1001":
                        hex = hex + "9";
                    break;
                    case "1010":
                        hex = hex + "A";
                    break;
                    case "1011":
                        hex = hex + "B";
                    break;
                    case "1100":
                        hex = hex + "C";
                    break;
                    case "1101":
                        hex = hex + "D";
                    break;
                    case "1110":
                        hex = hex + "E";
                    break;
                    case "1111":
                        hex = hex + "F";
                    break;
                }
            }

            string hexInvertido = "";
            for(int k = 0; k < 8; k = k + 2)
            {
                hexInvertido = hex.Substring(k, 2) + " " + hexInvertido;
            }

            // Console.WriteLine("Hexadecimal: " + hex);
            // Console.WriteLine("Hexadecimal invertido: " + hexInvertido);

            Console.WriteLine("\t32 bits ==> " + hexInvertido);
        }
    }
}
