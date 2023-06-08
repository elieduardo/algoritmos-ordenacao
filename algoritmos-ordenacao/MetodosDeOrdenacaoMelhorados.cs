namespace algoritmos_ordenacao
{
    public class MetodosDeOrdenacaoMelhorados
    {
        // Metodo para validar ordenação da lista
        public bool ValidarOrdenacao(List<int> lista)
        {
            return lista.SequenceEqual(lista.OrderBy(x => x));
        }

        // Percorre a lista várias vezes, comparando elementos adjacentes e trocando-os se estiverem na ordem errada.
        public List<int> BubbleSort(List<int> lista)
        {
            var listaOrdenada = new List<int>(lista);
            bool trocaFeita;

            // variável para guardar a quantidade de elementos (index) da lista
            int quantidade = listaOrdenada.Count - 1;

            // passa pelo menos uma vez pela lista vendo se existe algum elemento fora de ordem
            do
            {
                trocaFeita = false;
                int novaQuantidade = 0;

                // percorre a lista
                for (int j = 0; j < quantidade; j++)
                {
                    if (listaOrdenada[j] > listaOrdenada[j + 1])
                    {
                        int temp = listaOrdenada[j];
                        listaOrdenada[j] = listaOrdenada[j + 1];
                        listaOrdenada[j + 1] = temp;
                        trocaFeita = true;
                        novaQuantidade = j;
                    }
                }

                // quando é feita a ordenação do elemento mais alto, não existe a necessidade de passar por ele novamente,
                // sendo assim, passa a valar o novo valor da variável quantidade
                quantidade = novaQuantidade;
            }
            // validação para ver se a lista já não está ordenada (se nenhuma troca for feita é por que já está ordenada)
            while (trocaFeita);

            return listaOrdenada;
        }

        // Encontra o menor elemento restante e o coloca em sua posição correta na lista.
        public List<int> SelectionSort(List<int> lista)
        {
            var listaOrdenada = new List<int>(lista);

            // Valida se a lista já está ordenada
            if (ValidarOrdenacao(lista))
            {
                return lista;
            }

            for (int i = 0; i < listaOrdenada.Count - 1; i++)
            {
                int indiceMenor = i;
                for (int j = i + 1; j < listaOrdenada.Count; j++)
                {
                    if (listaOrdenada[j] < listaOrdenada[indiceMenor])
                    {
                        indiceMenor = j;
                    }
                }

                if (indiceMenor != i)
                {
                    int temp = listaOrdenada[i];
                    listaOrdenada[i] = listaOrdenada[indiceMenor];
                    listaOrdenada[indiceMenor] = temp;
                }
            }

            return listaOrdenada;
        }

        // Percorre a lista, inserindo cada elemento em sua posição correta na parte já classificada da lista.
        public List<int> InsertionSort(List<int> lista)
        {
            var listaOrdenada = new List<int>(lista);

            // Valida se a lista já está ordenada
            if (ValidarOrdenacao(lista))
            {
                return lista;
            }

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

            // Valida se a lista já está ordenada
            if (ValidarOrdenacao(lista))
            {
                return lista;
            }

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

            // Valida se a lista já está ordenada
            if (ValidarOrdenacao(lista))
            {
                return lista;
            }


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

            // Valida se a lista já está ordenada
            if (ValidarOrdenacao(lista))
            {
                return lista;
            }

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
