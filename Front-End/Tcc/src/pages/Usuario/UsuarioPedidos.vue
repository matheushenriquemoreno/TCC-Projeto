<template>
  <q-card>
    <div class="q-pa-md q-gutter-sm">
      <q-icon name="person" /> Usuario Pedidos
    </div>
    <q-card-section> </q-card-section>
  </q-card>
</template>

<script lang="ts">
import useUsuarioLogado from 'src/stores/UsuarioLogadoStore';
import { defineComponent, onMounted, ref } from 'vue';
import { useRouter } from 'vue-router';

export default defineComponent({
  name: 'UsuarioPedidos',
  components: {},
  setup() {
    const usuarioLogadoStore = useUsuarioLogado();

    return {};
  },
});
</script>

<style scoped>
.page {
  background: #e2e2e5;
  height: calc(100%);
  place-content: center;
  width: calc(100%);
}
</style>
