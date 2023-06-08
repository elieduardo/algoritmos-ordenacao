namespace algoritmos_ordenacao
{
    public delegate List<int> MetodoDelegate(List<int> lista);

    class Program
    {
        static int QUANTIDADE_EXECUCAO = 1;
        static void Main()
        {
            MetodosDeOrdenacaoClassicos metodosDeOrdenacaoClassicos = new MetodosDeOrdenacaoClassicos();
            MetodosDeOrdenacaoMelhorados metodosDeOrdenacaoMelhorados = new MetodosDeOrdenacaoMelhorados();
            Uteis uteis = new Uteis();

            string caminhoArquivo = uteis.ObterCaminhaoDiretorio();
            uteis.SolicitarQuantidadeExecucao(QUANTIDADE_EXECUCAO);
            List<Dictionary<string, List<int>>> listaDicionario = uteis.GerarListasDicionario();

            using (StreamWriter streamWriter = new StreamWriter(caminhoArquivo))
            {
                foreach (var dicionario in listaDicionario)
                {
                    foreach (var lista in dicionario)
                    {
                        Console.WriteLine($"------ {lista.Key} ------");
                        streamWriter.WriteLine($"************************************************");
                        streamWriter.WriteLine($"------ {lista.Key} ------");
                        uteis.ImprimirInformacoes(lista.Value, streamWriter, QUANTIDADE_EXECUCAO);
                        streamWriter.WriteLine($"********** Métodos Clássicos **********");
                        streamWriter.WriteLine("---- Algoritmos de ordenação simples ----");
                        uteis.AnalisarTempoMetodo(metodosDeOrdenacaoClassicos.BubbleSort, lista.Value, streamWriter, QUANTIDADE_EXECUCAO);
                        uteis.AnalisarTempoMetodo(metodosDeOrdenacaoClassicos.SelectionSort, lista.Value, streamWriter, QUANTIDADE_EXECUCAO);
                        uteis.AnalisarTempoMetodo(metodosDeOrdenacaoClassicos.InsertionSort, lista.Value, streamWriter, QUANTIDADE_EXECUCAO);
                        streamWriter.WriteLine($"---- Algoritmos de ordenação complexos eficientes ----");
                        uteis.AnalisarTempoMetodo(metodosDeOrdenacaoClassicos.MergeSort, lista.Value, streamWriter, QUANTIDADE_EXECUCAO);
                        uteis.AnalisarTempoMetodo(metodosDeOrdenacaoClassicos.HeapSort, lista.Value, streamWriter, QUANTIDADE_EXECUCAO);
                        uteis.AnalisarTempoMetodo(metodosDeOrdenacaoClassicos.QuickSort, lista.Value, streamWriter, QUANTIDADE_EXECUCAO);

                        streamWriter.WriteLine($"********** Métodos Melhorados **********");
                        streamWriter.WriteLine("---- Algoritmos de ordenação simples ----");
                        uteis.AnalisarTempoMetodo(metodosDeOrdenacaoMelhorados.BubbleSort, lista.Value, streamWriter, QUANTIDADE_EXECUCAO);
                        uteis.AnalisarTempoMetodo(metodosDeOrdenacaoMelhorados.SelectionSort, lista.Value, streamWriter, QUANTIDADE_EXECUCAO);
                        uteis.AnalisarTempoMetodo(metodosDeOrdenacaoMelhorados.InsertionSort, lista.Value, streamWriter, QUANTIDADE_EXECUCAO);
                        streamWriter.WriteLine($"---- Algoritmos de ordenação complexos eficientes ----");
                        uteis.AnalisarTempoMetodo(metodosDeOrdenacaoMelhorados.MergeSort, lista.Value, streamWriter, QUANTIDADE_EXECUCAO);
                        uteis.AnalisarTempoMetodo(metodosDeOrdenacaoMelhorados.HeapSort, lista.Value, streamWriter, QUANTIDADE_EXECUCAO);
                        uteis.AnalisarTempoMetodo(metodosDeOrdenacaoMelhorados.QuickSort, lista.Value, streamWriter, QUANTIDADE_EXECUCAO);
                    }
                }
            }
        }
    }
}
