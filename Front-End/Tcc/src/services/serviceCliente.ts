import { AxiosError, AxiosInstance } from 'axios';
import { Cliente, LoginUser, UserLogado } from './interfaces/Cliente';
import { ResultErro } from './interfaces/Result';
import { Notify } from 'quasar';
import obterAxios from './Base/ObterAxios';

export class ServiceCliente {
  api: AxiosInstance;

  constructor() {
    this.api = obterAxios('https://localhost:7115/api');
  }
  async cadastrarCliente(cliente: Cliente) {
    const result = await this.api.post<UserLogado>(
      '/Cliente/AdicionarELogar',
      cliente
    );
    return result.data as UserLogado;
  }
  async cadastrarEnderecoCliente(endereco: any) {
    const result = await this.api.post('/Cliente/GerenciarEndereco', endereco);
    return result.status === 200;
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
