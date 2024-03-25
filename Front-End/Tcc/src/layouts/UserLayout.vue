<template>
  <q-layout view="hHh lpR fFf" class="shadow-2 rounded-borders">
    <q-header elevated class="bg-teal-5 text-dark">
      <q-toolbar>
        <q-toolbar-title class="text-center">
          <q-avatar>
            <img :src="logo" />
          </q-avatar>
          <span class="text-weight-bolder q-ml-sm">Ecommerce Esportivo</span>
        </q-toolbar-title>
      </q-toolbar>
    </q-header>

    <q-page-container>
      <router-view />
    </q-page-container>
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
