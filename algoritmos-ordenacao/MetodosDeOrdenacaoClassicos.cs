namespace algoritmos_ordenacao
{
    public class MetodosDeOrdenacaoClassicos
    {
        // Percorre a lista várias vezes, comparando elementos adjacentes e trocando-os se estiverem na ordem errada.
        public List<int> BubbleSort(List<int> lista)
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

            return listaOrdenada;
        }

        // Encontra o menor elemento restante e o coloca em sua posição correta na lista.
        public List<int> SelectionSort(List<int> lista)
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

            return listaOrdenada;
        }

        // Percorre a lista, inserindo cada elemento em sua posição correta na parte já classificada da lista.
        public List<int> InsertionSort(List<int> lista)
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

            return listaOrdenada;
        }

        // Recursivamente divide a lista em duas metades e as mescla em ordem.
        public List<int> MergeSort(List<int> lista)
        {
            if (lista.Count <= 1)
                return lista;

            int meio = lista.Count / 2;
            List<int> metadeEsquerda = new List<int>();
            List<int> metadeDireita = new List<int>();

            for (int i = 0; i < meio; i++)
            {
                metadeEsquerda.Add(lista[i]);
            }

            for (int i = meio; i < lista.Count; i++)
            {
                metadeDireita.Add(lista[i]);
            }

            metadeEsquerda = MergeSort(metadeEsquerda);
            metadeDireita = MergeSort(metadeDireita);

            return Merge(metadeEsquerda, metadeDireita);
        }

        // Combina duas listas ordenadas em uma única lista ordenada.
        private List<int> Merge(List<int> metadeEsquerda, List<int> metadeDireita)
        {
            List<int> listaOrdenada = new List<int>();
            int indiceEsquerda = 0;
            int indiceDireita = 0;

            while (indiceEsquerda < metadeEsquerda.Count && indiceDireita < metadeDireita.Count)
            {
                if (metadeEsquerda[indiceEsquerda] <= metadeDireita[indiceDireita])
                {
                    listaOrdenada.Add(metadeEsquerda[indiceEsquerda]);
                    indiceEsquerda++;
                }
                else
                {
                    listaOrdenada.Add(metadeDireita[indiceDireita]);
                    indiceDireita++;
                }
            }

            while (indiceEsquerda < metadeEsquerda.Count)
            {
                listaOrdenada.Add(metadeEsquerda[indiceEsquerda]);
                indiceEsquerda++;
            }

            while (indiceDireita < metadeDireita.Count)
            {
                listaOrdenada.Add(metadeDireita[indiceDireita]);
                indiceDireita++;
            }

            return listaOrdenada;
        }

        // Extrai o elemento raiz (maior) da árvore heap e o coloca na posição correta.
        public List<int> HeapSort(List<int> lista)
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

            return listaOrdenada;
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
        public List<int> QuickSort(List<int> lista)
        {
            var listaOrdenada = new List<int>(lista);
            QuickSort(listaOrdenada, 0, listaOrdenada.Count - 1);
            return listaOrdenada;
        }

        // Troca os elementos nas posições left e right da lista.
        static void Swap(List<int> items, int left, int right)
        {
            if (left != right)
            {
                int temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }

        // Chama o método QuickSort recursivamente para ordenar a lista.
        static private void QuickSort(List<int> items, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = (left + right) / 2;

                int newPivot = Partition(items, left, right, pivotIndex);
                QuickSort(items, left, newPivot - 1);
                QuickSort(items, newPivot + 1, right);
            }
        }

        // Responsável por particionar a lista com base no pivô selecionado
        static private int Partition(List<int> items, int left, int right, int pivotIndex)
        {
            int pivotValue = items[pivotIndex];

            Swap(items, pivotIndex, right);

            int storeIndex = left;

            for (int i = left; i < right; i++)
            {
                if (items[i].CompareTo(pivotValue) < 0)
                {
                    Swap(items, i, storeIndex);
                    storeIndex += 1;
                }
            }

            Swap(items, storeIndex, right);
            return storeIndex;
        }
    }
}
