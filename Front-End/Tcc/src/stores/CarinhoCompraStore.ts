import { defineStore } from 'pinia';
import {
  CarinhoCompra,
  ItemCarinho,
  ProdutoCarinho,
} from 'src/services/interfaces/CarinhoDeCompra';
import Produto from 'src/services/interfaces/Produto';
import useUsuarioLogado from './UsuarioLogadoStore';
import { ObterServicoCarrinho } from 'src/services/ServiceCarinho';

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
    async adicionarNoCarinho(produto: Produto) {
      const userStore = useUsuarioLogado();
      const serviceCarrinho = ObterServicoCarrinho();

      if (userStore.usuarioEstaLogado()) {
        await serviceCarrinho.adicionarProdutoCarinho(produto.id, 1);

        this.carinho = await serviceCarrinho.obterProdutosCarinho();
      } else {
        const indexProduto = this.carinho.produtos.findIndex(
          (x) => x.produtoCarinho.idProduto === produto.id
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
            urlImagePrincipal: produto.urlImagens[0],
            descricao: produto.descricao,
          };

          const itemCarinho: ItemCarinho = {
            produtoCarinho: produtoCarinho,
            quantidade: 1,
          };

          this.carinho.produtos.push(itemCarinho);
        }

        this.setarValorTotal();
        localStorage.setItem('carinho', JSON.stringify(this.carinho));
      }
    },
    adicionarQuantidade(idProduto: number) {
      const indexProduto = this.carinho.produtos.findIndex(
        (x) => x.produtoCarinho.idProduto === idProduto
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
        (x) => x.produtoCarinho.idProduto === idProduto
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
        (x) => x.produtoCarinho.idProduto != idProduto
      );
      this.setarValorTotal();
      localStorage.setItem('carinho', JSON.stringify(this.carinho));
    },
    setarValorTotal() {
      let valor = 0;

      this.carinho.produtos.forEach((x) => {
        valor += x.produtoCarinho.preco * x.quantidade;
      });

      this.carinho.valorTotal = valor;
    },
    async obterCarinho() {
      const userStore = useUsuarioLogado();
      const serviceCarrinho = ObterServicoCarrinho();
      if (userStore.usuarioEstaLogado()) {
        this.carinho = await serviceCarrinho.obterProdutosCarinho();
        console.log(this.carinho);
      } else {
        const carinho = localStorage.getItem('carinho');
        if (carinho) {
          this.carinho = JSON.parse(carinho!) as CarinhoCompra;
        }
        return this.carinho;
      }
    },
  },
});
