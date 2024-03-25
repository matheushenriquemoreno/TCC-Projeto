<template>
  <q-dialog v-model="showCarinhoLocal" position="right" full-height>
    <q-card class="carinhoCompra">
      <q-card-section>
        <div class="text-h6 text-center text-teal">
          ITENS NO MEU CARRINHO ({{ itensCarinho }})
        </div>
      </q-card-section>

      <q-separator />

      <q-card-section class="q-mt-sm">
        <div v-for="item in carinho.produtos" :key="item.produto.idProduto">
          <ProdutoCarinho :item="item" />
        </div>
      </q-card-section>

      <q-card-section class="q-mt-sm">
        <q-card class="my-card shadow-6">
          <q-card-section class="text-center" style="height: 55px">
            <div class="text-weight-medium" style="font-size: 17px">
              Resumo do pedido
            </div>
          </q-card-section>
          <q-separator />
          <q-card-section class="text-center">
            <div class="row justify-between">
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
            <span class="text-subtitle1 text-weight-bold text-green"
              >Valor com 10% de desconto no boleto ou PIX</span
            >
          </q-card-section>
        </q-card>
      </q-card-section>

      <q-card-actions align="center">
        <q-btn
          icon="shopping_cart"
          label="Ir para o carinho"
          color="green"
          to="/CarinhoCompra"
          v-close-popup
        />
      </q-card-actions>
    </q-card>
  </q-dialog>
</template>

<script lang="ts">
import { computed, defineComponent, ref } from 'vue';
import ProdutoCarinho from './ProdutoCarinho.vue';
import { useCarinhoCompraStore } from 'src/stores/CarinhoCompraStore';

export default defineComponent({
  name: 'CarinhoCompras',

  components: { ProdutoCarinho },
  emits: ['update:showCarinho'],
  props: {
    showCarinho: Boolean,
  },
  computed: {
    showCarinhoLocal: {
      get(): boolean {
        return this.showCarinho;
      },
      set(value: boolean) {
        this.$emit('update:showCarinho', value);
      },
    },
  },
  setup() {
    const carinhoStore = useCarinhoCompraStore();
    carinhoStore.obterCarinho();
    const carinho = computed(() => carinhoStore.carinho);
    const itensCarinho = computed(() => carinhoStore.quantidadeItens);

    return { carinho, itensCarinho };
  },
});
</script>

<style scoped>
.carinhoCompra {
  width: 550px;
  height: 100%;
}
</style>
