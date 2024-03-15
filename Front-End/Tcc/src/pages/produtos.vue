<template>
  <q-page class="row">
    <div class="col-12 text-center q-mt-sm">
      <span class="text-h4"> Aproveite as melhores ofertas</span>
      <div class="q-pa-lg row items-start q-gutter-md">
        <ProdutoCompra
          v-for="produto in produtos"
          :key="produto.id"
          :label="produto.nome"
          :preco="produto.preco"
          :descricao="produto.descricao"
          :url-image="produto.urlImagens[0]"
        />
      </div>
    </div>
  </q-page>
</template>

<script lang="ts">
import { defineComponent, onMounted, onUpdated, ref } from 'vue';

import ProdutoCompra from 'src/components/Produto/ProdutoCompra.vue';
import { useRoute } from 'vue-router';
import ObterServiceProduto from 'src/services/serviceProduto';
import Produto from 'src/services/interfaces/Produto';

export default defineComponent({
  name: 'IndexPage',
  components: { ProdutoCompra },
  setup() {
    const router = useRoute();
    const produtos = ref<Array<Produto>>();
    const service = ObterServiceProduto();
    const getCategoria = () => {
      const categoria = router.params['IdCategoria'];

      if (Array.isArray(categoria)) {
        return parseInt(categoria[0]);
      }

      return parseInt(categoria);
    };

    console.log(getCategoria());

    onMounted(async () => {
      produtos.value = await service.ObterProdutosPelaCategoria(getCategoria());
    });

    onUpdated(async () => {
      produtos.value = await service.ObterProdutosPelaCategoria(getCategoria());
    });

    return { produtos };
  },
});
</script>

<style lang="sass" scoped>
.my-card
  width: 100%
  max-width: 300px
</style>
