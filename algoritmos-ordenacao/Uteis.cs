using System.Diagnostics;

namespace algoritmos_ordenacao
{
    public class Uteis
    {
        public List<Dictionary<string, List<int>>> GerarListasDicionario()
        {
            List<Dictionary<string, List<int>>> listaDicionario = new List<Dictionary<string, List<int>>>();
            listaDicionario.Add(GerarListas(0, 1000));
            listaDicionario.Add(GerarListas(0, 10000));
            listaDicionario.Add(GerarListas(0, 50000));
            listaDicionario.Add(GerarListas(0, 100000));
            listaDicionario.Add(GerarListas(0, 500000));
            listaDicionario.Add(GerarListas(0, 1000000));
            return listaDicionario;
        }

        public string ObterCaminhaoDiretorio()
        {
            return $"{AppDomain.CurrentDomain.BaseDirectory}/execucao_{DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss")}.txt";
        }

        public void ImprimirInformacoes(List<int> lista, StreamWriter streamWriter, int qntExecucoes)
        {
            streamWriter.WriteLine($"Carga de {lista.Count()} elementos");
            streamWriter.WriteLine($"Valor mínimo: {lista.Min()}, valor máximo: {lista.Max()}");
            streamWriter.WriteLine($"Média de {qntExecucoes} execuções\n");
        }

        public void ValidarOrdenacao(List<int> lista, string nomeMetodo, StreamWriter streamWriter)
        {
            if (!lista.SequenceEqual(lista.OrderBy(x => x).ToList()))
            {
                streamWriter.WriteLine($" **** *** ** * NÃO ORDENOU CORRETAMENTE {nomeMetodo} * ** *** ****");
            }
        }

        public void SolicitarQuantidadeExecucao(int quantidadeExecucao)
        {
            bool sucessoLeitura = false;
            while (!sucessoLeitura)
            {
                Console.WriteLine($"Digite a quantidade de execucao:");
                string? input = Console.ReadLine();
                sucessoLeitura = int.TryParse(input, out quantidadeExecucao);
            }
        }

        public void AnalisarTempoMetodo(MetodoDelegate metodo, List<int> lista, StreamWriter streamWriter, int quantidadeExecucao)
        {
            Console.WriteLine($"Executando {metodo.Method.Name}...");
            streamWriter.WriteLine($"{metodo.Method.Name}");
            var listaOrdenada = new List<int>();
            long tempo = 0;
            for (int i = 0; i < quantidadeExecucao; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                listaOrdenada = metodo(lista);
                stopwatch.Stop();
                tempo += stopwatch.ElapsedTicks;
            }

            TimeSpan mediaExecucao = new TimeSpan(tempo / quantidadeExecucao);
            streamWriter.WriteLine($"tempo de execução: {mediaExecucao}\n");
            Console.WriteLine($"{metodo.Method.Name} executado em {mediaExecucao}");
            ValidarOrdenacao(listaOrdenada, metodo.Method.Name, streamWriter);
        }

        private Dictionary<string, List<int>> GerarListas(int minimo, int quantidade)
        {
            Console.WriteLine("Gerando listas");
            Dictionary<string, List<int>> listas = new Dictionary<string, List<int>>();
            List<int> listaAleatoria = GerarListaAleatoria(minimo, quantidade);
            List<int> listaOrdenadaAsc = listaAleatoria.OrderBy(x => x).ToList();
            List<int> listaOrdenadaDesc = listaAleatoria.OrderByDescending(x => x).ToList();
            List<int> listaQuaseOrdenada = ListaQuaseOrdenada(listaOrdenadaAsc);

            listas.Add("Lista Aleatória", listaAleatoria);
            listas.Add("Lista Ordenada", listaOrdenadaAsc);
            listas.Add("Lista Inversamente Ordenada", listaOrdenadaDesc);
            listas.Add("Lista Quase Ordenada", listaQuaseOrdenada);
            Console.WriteLine("Listas geradadas");
            return listas;
        }

        private List<int> GerarListaAleatoria(int minimo, int quantidade)
        {
            List<int> lista = new List<int>();

            while (lista.Count < quantidade)
            {
                Random rand = new Random();
                var novoNumero = rand.Next(minimo, quantidade * 2);

                if (!lista.Contains(novoNumero))
                    lista.Add(novoNumero);
            }

            return lista;
        }

        private List<int> ListaQuaseOrdenada(List<int> lista)
        {
            List<int> listaQuaseOrdenada = lista.OrderBy(x => x).ToList();

            for (int i = 0; i < listaQuaseOrdenada.Count; i++)
            {
                if (i % 10 == 0)
                {
                    int indiceAntigo = i;
                    int indiceNovo = i + 1;
                    int valor = listaQuaseOrdenada[i];
                    listaQuaseOrdenada.RemoveAt(indiceAntigo);
                    listaQuaseOrdenada.Insert(indiceNovo, valor);
                }

            }

            return lista;
        }
    }
}
