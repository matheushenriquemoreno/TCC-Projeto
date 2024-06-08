<template>
  <q-card flat bordered class="my-card">
    <q-card-section horizontal style="height: 150px">
      <img
        class="col-4"
        :src="item.produtoCarinho.urlImagePrincipal"
        style="object-fit: scale-down"
      />
      <q-card-section
        style="height: 150px"
        class="text-center col-8 self-center text-weight-bold text-body1"
      >
        {{ item.produtoCarinho.nome }}
      </q-card-section>
    </q-card-section>

    <q-separator />

    <q-card-actions align="between">
      <div class="text-dark">
        <q-btn
          :disable="item.quantidade == 1"
          flat
          round
          icon="remove"
          size="md"
          @click="
            () => carinhoStore.diminuirQuantidade(item.produtoCarinho.idProduto)
          "
        />
        <q-chip square color="grey" style="font-size: 17"
          ><b>{{ item.quantidade }}</b></q-chip
        >
        <q-btn
          flat
          icon="add"
          size="md"
          @click="
            () =>
              carinhoStore.adicionarQuantidade(item.produtoCarinho.idProduto)
          "
        />
        <q-btn
          flat
          icon="delete"
          size="md"
          @click="
            () =>
              carinhoStore.removerProdutoCarinho(item.produtoCarinho.idProduto)
          "
        />
      </div>
      <div>
        <b class="text-teal">
          {{
            (item.produtoCarinho.preco * item.quantidade).toLocaleString(
              'pt-br',
              {
                style: 'currency',
                currency: 'BRL',
              }
            )
          }}</b
        >
      </div>
    </q-card-actions>
  </q-card>
</template>

<script lang="ts">
import { ItemCarinho } from 'src/services/interfaces/CarinhoDeCompra';
import { useCarinhoCompraStore } from 'src/stores/CarinhoCompraStore';
import { PropType, defineComponent, ref, onMounted, onUpdated } from 'vue';

export default defineComponent({
  name: 'ProdutoCarinho',
  components: {},
  computed: {},
  props: {
    item: {
      type: {} as PropType<ItemCarinho>,
      required: true,
    },
  },
  setup() {
    const carinhoStore = useCarinhoCompraStore();

    return { carinhoStore };
  },
});
</script>

<style lang="sass" scoped>
.my-card
  width: 100%
  height: 200px
</style>
