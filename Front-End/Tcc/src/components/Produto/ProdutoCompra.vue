<template>
  <q-card class="my-card" flat bordered>
    <q-img
      class="imagemProduto"
      :src="
        produto.urlImagens[0] ||
        'https://upload.wikimedia.org/wikipedia/commons/a/a3/Image-not-found.png'
      "
    />
    <q-rating v-model="stars" color="teal" :max="5" size="32px" />
    <div>
      <q-card-section>
        <div class="row no-wrap items-center">
          <div class="" style="font-size: 20px">{{ produto.nome }}</div>
        </div>
      </q-card-section>

      <q-card-section class="q-pt-none">
        <div class="text-teal">
          <b>
            {{
              produto.preco?.toLocaleString('pt-br', {
                style: 'currency',
                currency: 'BRL',
              })
            }}</b
          >
        </div>
        <div class="text-caption text-grey">
          {{ produto.descricao }}
        </div>
      </q-card-section>

      <q-card-actions class="row no-wrap justify-center">
        <q-btn
          outline
          unelevated
          class="text-center"
          color="teal"
          label="Adicionar no carinho"
          @click="() => adicionarProduto(produto)"
        />
      </q-card-actions>
    </div>
  </q-card>
</template>

<script lang="ts">
import { PropType, defineComponent, ref } from 'vue';
import Produto from 'src/services/interfaces/Produto';
import { useCarinhoCompraStore } from 'src/stores/CarinhoCompraStore';
import { useQuasar } from 'quasar';

export default defineComponent({
  name: 'ProdutoCompra',
  components: {},
  props: {
    produto: {
      type: {} as PropType<Produto>,
      required: true,
    },
  },
  setup() {
    const $q = useQuasar();

    const carinhoStore = useCarinhoCompraStore();
    function adicionarProduto(produto: Produto) {
      carinhoStore.adicionarNoCarinho(produto);

      $q.notify({
        message: 'Ação realizada com sucesso!',
        caption: produto.nome,
        type: 'positive',
      });
    }

    return {
      stars: ref(Math.floor(Math.random() * 4) + 2),
      adicionarProduto,
      carinhoStore,
    };
  },
});
</script>

<style lang="sass" scoped>
.my-card
  width: 100%
  max-width: 300px
</style>

<style scoped></style>
