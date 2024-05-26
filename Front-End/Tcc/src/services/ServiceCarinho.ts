import { AxiosInstance } from 'axios';
import obterAxios from './Base/ObterAxios';
import { CarinhoCompra } from './interfaces/CarinhoDeCompra';

class ServiceCarrinho {
  api: AxiosInstance;

  constructor() {
    const urlApiFechamentoDePedidos = 'https://localhost:7176/api';
    this.api = obterAxios(urlApiFechamentoDePedidos);
  }

  async adicionarProdutoCarinho(idProduto: number, quantidade: number) {
    const result = await this.api.post('/Carrinho/Adicionar', {
      idProduto,
      quantidade,
    });
    return result.status === 200;
  }

  async diminuirProdutoCarinho(idProduto: number, quantidade: number) {
    const result = await this.api.post('/Carrinho/Diminuir', {
      idProduto,
      quantidade,
    });
    return result.status === 200;
  }

  async removerProdutoCarinho(idProduto: number) {
    const result = await this.api.post('/Carrinho/Remover', {
      idProduto,
    });
    return result.status === 200;
  }

  async obterProdutosCarinho() {
    const result = await this.api.get<CarinhoCompra>('/Carrinho');
    return result.data;
  }
}

export function ObterServicoCarrinho() {
  return new ServiceCarrinho();
}
