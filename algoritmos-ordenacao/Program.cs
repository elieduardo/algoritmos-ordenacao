using System.Diagnostics;

namespace algoritmos_ordenacao
{
    delegate void MetodoDelegate(List<int> lista);

    class Program
    {
        const int VALOR_MINIMO = 0;
        const int QUANTIDADE_ELEMENTOS = 1000000;
        const int QUANTIDADE_EXECUCAO = 10;
        static void Main()
        {
            MetodosDeOrdenacao metodosDeOrdenacao = new MetodosDeOrdenacao();
            Uteis uteis = new Uteis();

            List<int> lista = uteis.GerarListaAleatoria(VALOR_MINIMO, QUANTIDADE_ELEMENTOS);
            uteis.ImprimirInformacoes(lista, QUANTIDADE_EXECUCAO);
            Console.WriteLine($"---- Algoritmos de ordenação simples ----");
            AnalisarTempoMetodo(metodosDeOrdenacao.BubbleSort, lista);
            AnalisarTempoMetodo(metodosDeOrdenacao.SelectionSort, lista);
            AnalisarTempoMetodo(metodosDeOrdenacao.InsertionSort, lista);
            Console.WriteLine($"---- Algoritmos de ordenação complexos eficientes ----");
            AnalisarTempoMetodo(metodosDeOrdenacao.MergeSort, lista);
            AnalisarTempoMetodo(metodosDeOrdenacao.HeapSort, lista);
            AnalisarTempoMetodo(metodosDeOrdenacao.QuickSort, lista);
            Console.ReadLine();
        }

        public static void AnalisarTempoMetodo(MetodoDelegate metodo, List<int> lista)
        {
            Console.WriteLine($"{metodo.Method.Name}");
            long tempo = 0;
            for (int i = 0; i < QUANTIDADE_EXECUCAO; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                metodo(lista);
                stopwatch.Stop();
                tempo += stopwatch.ElapsedTicks;
            }

            TimeSpan mediaExecucao = new TimeSpan(tempo / QUANTIDADE_EXECUCAO);
            Console.WriteLine($"tempo de execução: {mediaExecucao}\n");
        }
    }
}
