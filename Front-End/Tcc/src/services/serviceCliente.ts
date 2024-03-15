import axios, { AxiosInstance } from 'axios';
import { Cliente } from './interfaces/Cliente';

export class ServiceCliente {
  api: AxiosInstance;

  constructor() {
    this.api = axios.create({
      baseURL: 'https://localhost:7115/api',
      timeout: 1000,
    });
  }
  async cadastrarCliente(cliente: Cliente) {
    const result = await this.api.post('/Cliente', cliente);

    console.log('Cliente Cadastrado!');

    return result.data;
  }
}

export default function ObterServiceCliente() {
  return new ServiceCliente();
}
