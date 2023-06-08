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
        // Particiona a lista em torno de um pivô e classifica as partições recursivamente.
        private static void QuickSort(List<int> lista, int inicio, int fim)
        {
            if (inicio < fim)
            {
                int indiceParticao = Particionar(lista, inicio, fim);

                QuickSort(lista, inicio, indiceParticao - 1);
                QuickSort(lista, indiceParticao + 1, fim);
            }
        }
        // Reorganiza a lista de forma que os elementos menores que o pivô estejam à esquerda e os maiores à direita.
        private static int Particionar(List<int> lista, int inicio, int fim)
        {
            int pivo = lista[fim];
            int i = inicio - 1;

            for (int j = inicio; j < fim; j++)
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
            lista[i + 1] = lista[fim];
            lista[fim] = temp1;

            return i + 1;
        }
    }
}
