<template>
  <q-page padding>
    <div class="text-center">
      <span class="text-h4"> Aproveite as melhores ofertas</span>
      <div class="row q-gutter-sm q-mt-md" v-if="produtos?.length > 0">
        <div v-for="item in produtos" :key="item.id">
          <ProdutoCompra :produto="item" />
        </div>
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
