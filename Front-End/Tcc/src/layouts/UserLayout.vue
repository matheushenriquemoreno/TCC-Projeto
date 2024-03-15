<template>
  <q-layout view="hHh lpR fFf" class="shadow-2 rounded-borders">
    <q-header elevated class="bg-dark text-white">
      <q-toolbar>
        <q-toolbar-title class="text-center">
          <q-avatar>
            <img :src="logo" />
          </q-avatar>
          Loja Esportiva
        </q-toolbar-title>
      </q-toolbar>
    </q-header>

    <q-page-container>
      <router-view />
    </q-page-container>
    <!--
    <q-footer class="text-white text-center" style="background: #e2e2e5">
      <q-avatar style="height: 100%; width: 80px">
        <q-img :src="logo" />
      </q-avatar>
    </q-footer>
    -->
  </q-layout>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { useRouter } from 'vue-router';

import logo from 'src/assets/Logo-1.jpg';

export default defineComponent({
  name: 'MainLayout',

  components: {},

  setup() {
    return {
      logo,
    };
  },
});
</script>
