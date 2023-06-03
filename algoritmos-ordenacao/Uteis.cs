namespace algoritmos_ordenacao
{
    public class Uteis
    {
        public List<int> GerarListaAleatoria(int minimo, int quantidade)
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

        public void ImprimirInformacoes(List<int> lista, int qntExecucoes)
        {
            Console.WriteLine($"Carga de {lista.Count()} elementos");
            Console.WriteLine($"Valor mínimo: {lista.Min()}, valor máximo: {lista.Max()}");
            Console.WriteLine($"Média de {qntExecucoes} execuções\n");
        }
    }
}
