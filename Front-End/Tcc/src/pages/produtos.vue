<template>
  <q-page class="row">
    <div class="col-12 text-center q-mt-sm">
      <span class="text-h4"> Aproveite as melhores ofertas</span>
      <div
        class="q-pa-lg row items-start q-gutter-md"
        v-if="produtos?.length > 0"
      >
        <ProdutoCompra
          v-for="item in produtos"
          :key="item.id"
          :produto="item"
        />
      </div>
      <div class="q-pa-md" v-else>
        <q-inner-loading
          :showing="true"
          label="Por favor aquarde"
          label-class="text-teal"
          label-style="font-size: 1.1em"
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
    const produtos = ref<Array<Produto>>([]);
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
