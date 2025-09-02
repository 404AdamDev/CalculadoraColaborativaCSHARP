using System;
using System.Collections.Generic;
using System.Data;

namespace CalculadoraWeb
{
    class Program
    {
        static List<string> historico = new List<string>(); // Definição de uma váriavel Lista para ser o histórico da calculadora
        static void Main(string[] args) // Função principal
        {
            int opcao;
            double num1 = 0, num2 = 0, resultado = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("===== Calculadora Colaborativa C# =====");
                Console.WriteLine("1 - Adição");
                Console.WriteLine("2 - Subtração");
                Console.WriteLine("3 - Multiplicação");
                Console.WriteLine("4 - Divisão");
                Console.WriteLine("5 - Raiz Quadrada");
                Console.WriteLine("6 - Parênteses");
                Console.WriteLine("7 - Histórico");
                Console.WriteLine("8 - Limpar Tela");

                Console.WriteLine("\n0 - Sair");
                Console.Write("Escolha uma opção: ");
                
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida. Pressione Enter para tentar novamente.");
                    Console.ReadLine();
                    continue;
                }

                if (opcao == 0)
                {
                    break;
                }

                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite o primeiro número: ");
                        num1 = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Digite o segundo número: ");
                        num2 = Convert.ToDouble(Console.ReadLine());

                        resultado = Adicao(num1, num2);
                        Console.WriteLine($"\nResultado: {resultado}");
                        break;
                    case 2:
                        Console.Write("Digite o primeiro número: ");
                        num1 = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Digite o segundo número: ");
                        num2 = Convert.ToDouble(Console.ReadLine());

                        resultado = Subtracao(num1, num2);
                        Console.WriteLine($"\nResultado: {resultado}");
                        break;
                    case 3:
                        Console.Write("Digite o primeiro número: ");
                        num1 = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Digite o segundo número: ");
                        num2 = Convert.ToDouble(Console.ReadLine());

                        resultado = Multiplicacao(num1, num2);
                        Console.WriteLine($"\nResultado: {resultado}");
                        break;
                    case 4:
                        Console.Write("Digite o primeiro número: ");
                        num1 = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Digite o segundo número: ");
                        num2 = Convert.ToDouble(Console.ReadLine());

                        if (num2 == 0)
                        {
                            Console.WriteLine("\nErro: Divisão por zero.");
                        }
                        else
                        {
                            resultado = Divisao(num1, num2);
                            Console.WriteLine($"\nResultado: {resultado}");
                        }
                        break;
                    case 5:
                        Console.Write("Digite o primeiro número: ");
                        num1 = Convert.ToDouble(Console.ReadLine());

                        resultado = RaizQuadrdada(num1);
                        Console.WriteLine($"\nResultado: {resultado}");
                        break;
                    case 6:
                        Parenteses();
                        break;
                    case 7:
                        MostrarHistorico();
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine($"Limpando a tela...");
                        break;
                }

                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine();

            } while (opcao != 0);

            Console.WriteLine("Encerrando calculadora. Até a próxima!");
        }

        // Integrante 4 (Adam)
        // Função para cadastrar uma nova operação(conta) no histórico da calculadora
        public static void RegistrarOperacao(string operacao)
        {
            if (historico.Count >= 8)
            {
                historico.RemoveAt(0);
            }
            historico.Add(operacao);
        }

        // Função para mostrar todas as ultimas opreações(contas) feitas pelo usuário durante a execução do sistema
        public static void MostrarHistorico()
        {
            Console.WriteLine("Últimos calculos:");
            foreach (var dado in historico)
            {
                Console.WriteLine(dado);
            }
            Console.WriteLine();
        }

        // Integrante 1 (João)
        // Função para somar dois números passados como parâmetros
        public static double Adicao(double a, double b)
        {
            double result = a + b;
            RegistrarOperacao($"{a} + {b} = {result}");
            return result;
        }

        // Integrante 2 (Matheus)
        // Função para subtrair dois números passados como parâmetros
        public static double Subtracao(double a, double b)
        {
            double result = a - b;
            RegistrarOperacao($"{a} - {b} = {result}");
            return result;
        }

        // Integrante 3 (Sophia)
        // Função para multiplicar dois números passados como parâmetros
        public static double Multiplicacao(double a, double b)
        {
            double result = a * b;
            RegistrarOperacao($"{a} * {b} = {result}");
            return result;
        }

        // Integrante 4 (Sophia)
        // Função para dividir dois números passados como parâmetros
        public static double Divisao(double a, double b)
        {
            double result = a / b;
            RegistrarOperacao($"{a} / {b} = {result}");
            return result;
        }

        // Integrante 5 (Marcus Rocha)
        // Função para calcular raizes quadradas (√2)
        public static double RaizQuadrdada(double a)
        {
            double result = Math.Sqrt(a);
            RegistrarOperacao($"√{a} = {result}");
            return result;
        }

        // Todos os Integrantes
        // Função para gerenciar o calculo de expressão numérica (parênteses)
        public static void Parenteses()
        {
            Console.WriteLine("Digite a expressão: ");
            string expressao = Console.ReadLine() ?? "0";

            try
            {
                DataTable dt = new DataTable();
                var resultado = dt.Compute(expressao, "");

                RegistrarOperacao($"{expressao} = {Convert.ToDouble(resultado)}");
                Console.WriteLine($"O valor da expressão é {Convert.ToDouble(resultado)}");
            }
            catch
            {
                Console.WriteLine("\nExpressão inválida!");
            }
        }
    }

}
