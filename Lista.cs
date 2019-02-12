using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class Lista<T>
    {
        private T[] _itens;
        private int _proximaPosicao;
        public int Tamanho { get { return _proximaPosicao; } }

        public Lista(int capacidadeInicial = 5)
        {
            _itens = new T[capacidadeInicial];
            _proximaPosicao = 0;
        }

        public void Adicionar(T item)
        {
            VerificarCapacidade(_proximaPosicao + 1);
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }


        public void AdicionarVarios(params T[] contaCorrentes)
        {
            foreach (var item in contaCorrentes)
            {
                Adicionar(item);
            }
        }


        public void Remover(T item)
        {
            int indice = -1;

            for (int i = 0; i < _proximaPosicao; i++)
            {
                T conta = _itens[i];
                if (conta.Equals(item))
                {
                    indice = i;
                    break;
                }
            }

            for (; indice < _proximaPosicao - 1; indice++)
            {
                _itens[indice] = _itens[indice + 1];
            }

            _proximaPosicao--;
            //_itens[_proximaPosicao] = null;
           
        }

        //public void Verlista()
        //{
        //    for (int i = 0; i < _proximaPosicao; i++)
        //    {
        //       ContaCorrente conat = _itens[i];
        //        Console.WriteLine("Agencia "+conat.Agencia+ " Numero "+ conat.Numero);
        //    }
        //}



        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }
            int novoTamanho = _itens.Length * 2;
            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

            T[] contas = new T[novoTamanho];

            foreach (var item in contas)
            {
                Array.Copy(_itens, contas, _itens.Length);
            }

            _itens = contas;

            //if (_itens.Contains(null))
            //{
            //    return;
            //}

        }

        public T GetIndex(int indice)
        {

            if (indice < 0 || indice == _proximaPosicao)
            {
                throw new ArgumentException(nameof(indice));
            }

            return _itens[indice];
        }

        public T this[int index]
        {
            get
            {
                return GetIndex(index);
            }
        }

    }
}
