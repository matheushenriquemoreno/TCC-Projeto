import { AxiosInstance } from 'axios';
import Produto from './interfaces/Produto';
import obterAxios from './Base/ObterAxios';

class ServiceProduto {
  api: AxiosInstance;

  constructor() {
    this.api = obterAxios('https://localhost:7017/api');
  }
  async ObterProdutos() {
    const result = await this.api.get<Array<Produto>>('/Produto');
    return result.data;
  }
  async ObterProdutosPelaCategoria(IdCategoria: number) {
    const result = await this.api.get<Array<Produto>>(
      `/Produto/ObterProdutosPorCategoria?Id=${IdCategoria}`
    );
    return result.data;
  }
}

export default function ObterServiceProduto() {
  return new ServiceProduto();
}
