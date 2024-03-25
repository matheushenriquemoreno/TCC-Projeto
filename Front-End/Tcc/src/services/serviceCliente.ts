import axios, { AxiosError, AxiosInstance } from 'axios';
import { Cliente, LoginUser, UserLogado } from './interfaces/Cliente';
import { ResultErro } from './interfaces/Result';
import { Notify } from 'quasar';

export class ServiceCliente {
  api: AxiosInstance;

  constructor() {
    this.api = axios.create({
      baseURL: 'https://localhost:7115/api',
      timeout: 1000,
    });
  }
  async cadastrarCliente(cliente: Cliente) {
    const result = await this.api.post<UserLogado>(
      '/Cliente/AdicionarELogar',
      cliente
    );
    return result.data as UserLogado;
  }

  async obterPeloId(id: number) {
    const result = await this.api.get('/Cliente/' + id);
    return result.data as Cliente;
  }

  async logar(login: LoginUser) {
    try {
      const result = await this.api.post<UserLogado>(
        '/Cliente/LogarCliente',
        login
      );
      return result.data as UserLogado;
    } catch (error) {
      const axiosError = error as AxiosError;
      if (axiosError.response?.data) {
        const erro = axiosError.response?.data as ResultErro;
        let mensageErro = '';

        erro.erros.forEach((element) => {
          mensageErro += `${element} \n`;
        });

        Notify.create({
          icon: 'announcement',
          message: mensageErro,
          timeout: 15 * 1000,
          type: 'negative',
          color: 'teal',
          progress: true,
          actions: [
            {
              icon: 'close',
              color: 'white',
              round: true,
            },
          ],
        });
      }

      return null;
    }
  }
}

export default function ObterServiceCliente() {
  return new ServiceCliente();
}
