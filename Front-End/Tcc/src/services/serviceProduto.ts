import axios, { AxiosInstance } from 'axios';
import Produto from './interfaces/Produto';

class ServiceProduto {
  api: AxiosInstance;

  constructor() {
    this.api = axios.create({
      baseURL: 'https://localhost:7017/api',
      timeout: 1000,
    });
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
