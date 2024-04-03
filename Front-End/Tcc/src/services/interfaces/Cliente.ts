export interface Endereco {
  idCliente: number;
  cep: string;
  rua: string;
  bairro: string;
  cidade: string;
  estado: string;
  complemento: string;
  numero: number;
}

export interface Cliente {
  id?: number;
  email: string;
  cpf: string;
  nomeCompleto: string;
  dataNascimento: Date;
  telefone: string;
  genero: number;
  senha: string;
  endereco?: Endereco;
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
