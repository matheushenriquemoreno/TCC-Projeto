<template>
  <q-card class="my-card text-center" flat bordered>
    <img
      style="height: 180px; width: 100%; object-fit: scale-down"
      :src="
        produto.urlImagens[0] ||
        'https://upload.wikimedia.org/wikipedia/commons/a/a3/Image-not-found.png'
      "
    />
    <div>
      <q-rating v-model="stars" color="teal" :max="5" size="25px" />
    </div>
    <div>
      <q-card-section>
        <span class="" style="font-size: 16px">{{ produto.nome }}</span>
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
      </q-card-section>

      <q-card-actions class="justify-center">
        <q-btn
          outline
          unelevated
          dense
          no-caps
          class="text-center"
          color="teal"
          label="Adicionar no Carinho"
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
        message: 'Produto adicionado ao carrino!',
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
  width: 200px
  height: 390px
</style>
