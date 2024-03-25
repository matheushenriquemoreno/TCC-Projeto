<template>
  <div class="row items-center justify-center q-mt-md">
    <div class="col-8">
      <q-icon name="shopping_cart" color="teal" size="sm" />
      <span class="text-h6 q-ml-sm">Meu carinho</span>
    </div>
  </div>

  <div class="row justify-center q-gutter-md q-mt-sm">
    <div class="col-md-6 col-11">
      <div
        class="q-mb-lg"
        v-for="item in carinho.produtos"
        :key="item.produto.idProduto"
      >
        <ProdutoCarinho :item="item" />
      </div>
    </div>
    <div class="col-md-2 col-11">
      <q-card class="my-card" flat bordered>
        <q-item>
          <q-item-section class="text-center">
            <q-item-label>Resumo</q-item-label>
          </q-item-section>
        </q-item>

        <q-separator />

        <q-card-section class="text-center">
          <div class="row justify-between q-mb-sm">
            <span class="text-subtitle1">Valor Total</span>
            <span class="text-green"
              ><b>{{
                carinho.valorTotal.toLocaleString('pt-br', {
                  style: 'currency',
                  currency: 'BRL',
                })
              }}</b></span
            >
          </div>
          <q-separator />
          <span class="text-subtitle1 text-weight-bold text-green"
            >Valor com 10% de desconto no boleto ou PIX</span
          >
        </q-card-section>

        <q-card-actions align="center" class="q-mb-sm">
          <q-btn
            icon="shopping_cart"
            label="Finalizar Pedido"
            color="green"
            to="/CarinhoCompra"
            v-close-popup
          />
        </q-card-actions>
      </q-card>
    </div>
  </div>
</template>

<script lang="ts">
import { useCarinhoCompraStore } from 'src/stores/CarinhoCompraStore';
import { computed, defineComponent } from 'vue';
import { useRouter } from 'vue-router';
import ProdutoCarinho from 'src/components/Carrinho/ProdutoCarinho.vue';

export default defineComponent({
  name: 'CarinhoCompraPage',
  components: { ProdutoCarinho },
  setup() {
    const rotas = useRouter();
    const carinhoStore = useCarinhoCompraStore();
    carinhoStore.obterCarinho();
    const carinho = computed(() => carinhoStore.carinho);
    const itensCarinho = computed(() => carinhoStore.quantidadeItens);

    return {
      rotas,
      carinho,
    };
  },
});
</script>
