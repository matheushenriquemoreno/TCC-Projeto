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
