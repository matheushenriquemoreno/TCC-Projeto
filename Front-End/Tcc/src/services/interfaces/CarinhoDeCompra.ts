export interface ProdutoCarinho {
  idProduto: number;
  nome: string;
  urlImage: string;
  preco: number;
}

export interface ItemCarinho {
  produto: ProdutoCarinho;
  quantidade: number;
}

export interface CarinhoCompra {
  produtos: Array<ItemCarinho>;
  valorTotal: number;
}
