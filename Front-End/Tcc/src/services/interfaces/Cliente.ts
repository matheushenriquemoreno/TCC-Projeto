export interface Cliente {
  id?: number;
  email: string;
  cpf: string;
  nomeCompleto: string;
  dataNascimento: Date;
  telefone: string;
  genero: number;
  senha: string;
}

export interface LoginUser {
  email: string;
  senha: string;
}

export interface UserLogado {
  token: string;
  nome: string;
  idCliente: number;
}
