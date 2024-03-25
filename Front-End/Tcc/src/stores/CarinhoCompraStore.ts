import { defineStore } from 'pinia';
import {
  CarinhoCompra,
  ItemCarinho,
  ProdutoCarinho,
} from 'src/services/interfaces/CarinhoDeCompra';
import Produto from 'src/services/interfaces/Produto';

const carinho: CarinhoCompra = {
  produtos: [],
  valorTotal: 0,
};

export const useCarinhoCompraStore = defineStore('CarinhoCompraStore', {
  state: () => ({
    carinho: carinho,
  }),
  getters: {
    quantidadeItens: (state) => state.carinho.produtos.length,
  },
  actions: {
    adicionarNoCarinho(produto: Produto) {
      const indexProduto = this.carinho.produtos.findIndex(
        (x) => x.produto.idProduto === produto.id
      );

      if (indexProduto >= 0) {
        const produtoExistente = this.carinho.produtos[indexProduto];
        produtoExistente.quantidade += 1;
        this.carinho.produtos[indexProduto] = produtoExistente;
      } else {
        const produtoCarinho: ProdutoCarinho = {
          idProduto: produto.id,
          nome: produto.nome,
          preco: produto.preco,
          urlImage: produto.urlImagens[0],
        };

        const itemCarinho: ItemCarinho = {
          produto: produtoCarinho,
          quantidade: 1,
        };

        this.carinho.produtos.push(itemCarinho);
      }

      this.setarValorTotal();
      localStorage.setItem('carinho', JSON.stringify(this.carinho));
    },
    adicionarQuantidade(idProduto: number) {
      const indexProduto = this.carinho.produtos.findIndex(
        (x) => x.produto.idProduto === idProduto
      );
      if (indexProduto >= 0) {
        const produtoExistente = this.carinho.produtos[indexProduto];
        produtoExistente.quantidade += 1;
        this.carinho.produtos[indexProduto] = produtoExistente;
      }
      this.setarValorTotal();
      localStorage.setItem('carinho', JSON.stringify(this.carinho));
    },
    diminuirQuantidade(idProduto: number) {
      const indexProduto = this.carinho.produtos.findIndex(
        (x) => x.produto.idProduto === idProduto
      );

      if (indexProduto >= 0) {
        const produtoExistente = this.carinho.produtos[indexProduto];

        if (produtoExistente.quantidade == 1) {
          this.removerProdutoCarinho(idProduto);
        } else {
          produtoExistente.quantidade -= 1;
          this.carinho.produtos[indexProduto] = produtoExistente;
        }
      }
      this.setarValorTotal();
      localStorage.setItem('carinho', JSON.stringify(this.carinho));
    },
    removerProdutoCarinho(idProduto: number) {
      this.carinho.produtos = this.carinho.produtos.filter(
        (x) => x.produto.idProduto != idProduto
      );
      this.setarValorTotal();
      localStorage.setItem('carinho', JSON.stringify(this.carinho));
    },
    setarValorTotal() {
      let valor = 0;

      this.carinho.produtos.forEach((x) => {
        valor += x.produto.preco * x.quantidade;
      });

      this.carinho.valorTotal = valor;
    },
    async obterCarinho() {
      const carinho = localStorage.getItem('carinho');
      if (carinho) {
        this.carinho = JSON.parse(carinho!) as CarinhoCompra;
      }
      return this.carinho;
    },
  },
});
