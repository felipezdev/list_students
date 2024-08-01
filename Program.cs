using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorDeEstudantes
{
    class Estudante
    {
        public string Nome { get; set; }
        public double Nota { get; set; }

        public Estudante(string nome, double nota)
        {
            Nome = nome;
            Nota = nota;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Nota: {Nota}";
        }
    }

    class Programa
    {
        static List<Estudante> estudantes = new List<Estudante>();

        static void Main(string[] args)
        {
            bool emExecucao = true;
            while (emExecucao)
            {
                Console.WriteLine("1. Adicionar Estudante");
                Console.WriteLine("2. Remover Estudante");
                Console.WriteLine("3. Exibir Todos os Estudantes");
                Console.WriteLine("4. Exibir Estudante com a Maior Nota");
                Console.WriteLine("5. Exibir Média das Notas");
                Console.WriteLine("6. Sair");
                Console.Write("Escolha uma opção: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AdicionarEstudante();
                        break;
                    case "2":
                        RemoverEstudante();
                        break;
                    case "3":
                        ExibirTodosOsEstudantes();
                        break;
                    case "4":
                        ExibirEstudanteComMaiorNota();
                        break;
                    case "5":
                        ExibirMediaDasNotas();
                        break;
                    case "6":
                        emExecucao = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                        break;
                }
            }
        }

        static void AdicionarEstudante()
        {
            Console.Write("Digite o nome do estudante: ");
            string nome = Console.ReadLine() ?? string.Empty;

            Console.Write("Digite a nota do estudante: ");
            if (double.TryParse(Console.ReadLine(), out double nota))
            {
                estudantes.Add(new Estudante(nome, nota));
                Console.WriteLine("Estudante adicionado com sucesso.");
            }
            else
            {
                Console.WriteLine("Nota inválida. Por favor, insira um número válido.");
            }
        }

        static void RemoverEstudante()
        {
            Console.Write("Digite o nome do estudante para remover: ");
            string nome = Console.ReadLine() ?? string.Empty;

            var estudante = estudantes.FirstOrDefault(s => s.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
            if (estudante != null)
            {
                estudantes.Remove(estudante);
                Console.WriteLine("Estudante removido com sucesso.");
            }
            else
            {
                Console.WriteLine("Estudante não encontrado.");
            }
        }

        static void ExibirTodosOsEstudantes()
        {
            if (estudantes.Count == 0)
            {
                Console.WriteLine("Nenhum estudante na lista.");
            }
            else
            {
                Console.WriteLine("Estudantes:");
                foreach (var estudante in estudantes)
                {
                    Console.WriteLine(estudante);
                }
            }
        }

        static void ExibirEstudanteComMaiorNota()
        {
            if (estudantes.Count == 0)
            {
                Console.WriteLine("Nenhum estudante na lista.");
            }
            else
            {
                var melhorEstudante = estudantes.OrderByDescending(s => s.Nota).First();
                Console.WriteLine($"Estudante com a maior nota: {melhorEstudante}");
            }
        }

        static void ExibirMediaDasNotas()
        {
            if (estudantes.Count == 0)
            {
                Console.WriteLine("Nenhum estudante na lista.");
            }
            else
            {
                double mediaNotas = estudantes.Average(s => s.Nota);
                Console.WriteLine($"Média das notas dos estudantes: {mediaNotas}");
            }
        }
    }
}
