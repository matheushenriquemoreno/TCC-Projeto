export interface ProdutoCarinho {
  idProduto: number;
  nome: string;
  descricao: string;
  urlImagePrincipal: string;
  preco: number;
}

export interface ItemCarinho {
  produtoCarinho: ProdutoCarinho;
  quantidade: number;
}

export interface CarinhoCompra {
  produtos: Array<ItemCarinho>;
  valorTotal: number;
}
