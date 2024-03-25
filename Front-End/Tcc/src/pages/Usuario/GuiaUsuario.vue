<template>
  <q-page class="row justify-center">
    <div class="col-12 q-pa-md">
      <div class="row q-gutter-sm justify-center">
        <div class="col-4 q-mr-lg">
          <q-list bordered separator class="bg-grey-12">
            <q-item clickable v-ripple to="/usuario/editar">
              <q-item-section avatar>
                <q-icon color="teal" name="person" />
              </q-item-section>
              <q-item-section>Minha Conta</q-item-section>
            </q-item>
            <q-item clickable v-ripple to="/usuario/enderecos">
              <q-item-section avatar>
                <q-icon color="teal" name="pin_drop" />
              </q-item-section>
              <q-item-section>Endereços Cadastrados</q-item-section>
            </q-item>

            <q-item clickable v-ripple to="/usuario/pedidos">
              <q-item-section avatar>
                <q-icon color="teal" name="grading" />
              </q-item-section>
              <q-item-section>Meus Pedidos</q-item-section>
            </q-item>
          </q-list>
        </div>
        <div class="col-6">
          <router-view></router-view>
        </div>
      </div>
    </div>
  </q-page>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'GuiaUsuario',
  components: {},
  setup() {
    return {};
  },
});
</script>
