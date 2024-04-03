<template>
  <q-card flat>
    <div class="q-pa-md q-gutter-sm">
      <q-breadcrumbs class="text-dark" active-color="dark">
        <template v-slot:separator>
          <q-icon size="1.2em" name="arrow_forward" color="teal" />
        </template>
        <q-breadcrumbs-el label="Usuário" />
        <q-breadcrumbs-el label="Pedidos" icon="grading" />
      </q-breadcrumbs>
    </div>
  </q-card>
</template>

<script lang="ts">
import useUsuarioLogado from 'src/stores/UsuarioLogadoStore';
import { defineComponent, onMounted, ref } from 'vue';

export default defineComponent({
  name: 'UsuarioPedidos',
  components: {},
  setup() {
    const usuarioLogadoStore = useUsuarioLogado();

    return {};
  },
});
</script>
