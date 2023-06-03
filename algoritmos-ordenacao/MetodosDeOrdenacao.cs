namespace algoritmos_ordenacao
{
    public class MetodosDeOrdenacao
    {
        // Percorre a lista várias vezes, comparando elementos adjacentes e trocando-os se estiverem na ordem errada.
        public void BubbleSort(List<int> lista)
        {
            var listaOrdenada = new List<int>(lista);

            for (int i = 0; i < listaOrdenada.Count - 1; i++)
            {
                for (int j = 0; j < listaOrdenada.Count - 1 - i; j++)
                {
                    if (listaOrdenada[j] > listaOrdenada[j + 1])
                    {
                        int temp = listaOrdenada[j];
                        listaOrdenada[j] = listaOrdenada[j + 1];
                        listaOrdenada[j + 1] = temp;
                    }
                }
            }
        }

        // Encontra o menor elemento restante e o coloca em sua posição correta na lista.
        public void SelectionSort(List<int> lista)
        {
            var listaOrdenada = new List<int>(lista);

            for (int i = 0; i < listaOrdenada.Count - 1; i++)
            {
                int indiceMinimo = i;
                for (int j = i + 1; j < listaOrdenada.Count; j++)
                {
                    if (listaOrdenada[j] < listaOrdenada[indiceMinimo])
                    {
                        indiceMinimo = j;
                    }
                }
                if (indiceMinimo != i)
                {
                    int temp = listaOrdenada[i];
                    listaOrdenada[i] = listaOrdenada[indiceMinimo];
                    listaOrdenada[indiceMinimo] = temp;
                }
            }
        }

        // Percorre a lista, inserindo cada elemento em sua posição correta na parte já classificada da lista.
        public void InsertionSort(List<int> lista)
        {
            var listaOrdenada = new List<int>(lista);

            for (int i = 1; i < listaOrdenada.Count; i++)
            {
                int chave = listaOrdenada[i];
                int j = i - 1;
                while (j >= 0 && listaOrdenada[j] > chave)
                {
                    listaOrdenada[j + 1] = listaOrdenada[j];
                    j--;
                }
                listaOrdenada[j + 1] = chave;
            }
        }

        // Recursivamente divide a lista em duas metades e as mescla em ordem.
        public void MergeSort(List<int> lista)
        {
            if (lista.Count <= 1)
                return;

            int meio = lista.Count / 2;
            var esquerda = new List<int>(lista.GetRange(0, meio));
            var direita = new List<int>(lista.GetRange(meio, lista.Count - meio));

            MergeSort(esquerda);
            MergeSort(direita);

            Merge(esquerda, direita);
        }

        // Combina duas listas ordenadas em uma única lista ordenada.
        private static void Merge(List<int> esquerda, List<int> direita)
        {
            var listaOrdenada = new List<int>();

            while (esquerda.Count > 0 && direita.Count > 0)
            {
                if (esquerda[0] <= direita[0])
                {
                    listaOrdenada.Add(esquerda[0]);
                    esquerda.RemoveAt(0);
                }
                else
                {
                    listaOrdenada.Add(direita[0]);
                    direita.RemoveAt(0);
                }
            }

            while (esquerda.Count > 0)
            {
                listaOrdenada.Add(esquerda[0]);
                esquerda.RemoveAt(0);
            }

            while (direita.Count > 0)
            {
                listaOrdenada.Add(direita[0]);
                direita.RemoveAt(0);
            }
        }

        // Extrai o elemento raiz (maior) da árvore heap e o coloca na posição correta.
        public void HeapSort(List<int> lista)
        {
            var listaOrdenada = new List<int>(lista);
            int n = listaOrdenada.Count;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(listaOrdenada, n, i);

            for (int i = n - 1; i >= 0; i--)
            {
                int temp = listaOrdenada[0];
                listaOrdenada[0] = listaOrdenada[i];
                listaOrdenada[i] = temp;

                Heapify(listaOrdenada, i, 0);
            }
        }

        private static void Heapify(List<int> lista, int n, int i)
        {
            int maior = i;
            int esquerda = 2 * i + 1;
            int direita = 2 * i + 2;

            if (esquerda < n && lista[esquerda] > lista[maior])
                maior = esquerda;

            if (direita < n && lista[direita] > lista[maior])
                maior = direita;

            if (maior != i)
            {
                int troca = lista[i];
                lista[i] = lista[maior];
                lista[maior] = troca;

                Heapify(lista, n, maior);
            }
        }

        // Quick Sort
        public void QuickSort(List<int> lista)
        {
            var listaOrdenada = new List<int>(lista);
            QuickSortRecursivo(listaOrdenada, 0, listaOrdenada.Count - 1);
        }
        // Particiona a lista em torno de um pivô e classifica as partições recursivamente.
        private static void QuickSortRecursivo(List<int> lista, int baixo, int alto)
        {
            if (baixo < alto)
            {
                int indiceParticao = Particionar(lista, baixo, alto);

                QuickSortRecursivo(lista, baixo, indiceParticao - 1);
                QuickSortRecursivo(lista, indiceParticao + 1, alto);
            }
        }
        // Reorganiza a lista de forma que os elementos menores que o pivô estejam à esquerda e os maiores à direita.
        private static int Particionar(List<int> lista, int baixo, int alto)
        {
            int pivo = lista[alto];
            int i = baixo - 1;

            for (int j = baixo; j < alto; j++)
            {
                if (lista[j] < pivo)
                {
                    i++;
                    int temp = lista[i];
                    lista[i] = lista[j];
                    lista[j] = temp;
                }
            }

            int temp1 = lista[i + 1];
            lista[i + 1] = lista[alto];
            lista[alto] = temp1;

            return i + 1;
        }
    }
}
