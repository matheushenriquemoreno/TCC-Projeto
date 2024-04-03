<template>
  <q-page class="row justify-center">
    <div class="col-12 q-pa-md">
      <div class="row q-gutter-md justify-center">
        <div class="col-md-3 col-12">
          <q-list bordered separator class="bg-grey-12">
            <q-item clickable v-ripple to="/usuario/editar">
              <q-item-section avatar>
                <q-icon color="teal" name="person" />
              </q-item-section>
              <q-item-section>Dados</q-item-section>
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
        <div class="col-md-7 col-12 myShadow q-pa-md">
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

<style scoped>
.myShadow {
  border-radius: 10px;
  box-shadow: rgba(17, 17, 26, 0.1) 0px 4px 16px,
    rgba(17, 17, 26, 0.1) 0px 8px 24px, rgba(17, 17, 26, 0.1) 0px 16px 56px;
}
</style>
