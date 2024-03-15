<template>
  <q-card class="my-card" flat bordered>
    <q-img
      :src="
        urlImage ||
        'https://upload.wikimedia.org/wikipedia/commons/a/a3/Image-not-found.png'
      "
    />

    <q-card-section>
      <div class="row no-wrap items-center">
        <div class="col text-h6">{{ label }}</div>
      </div>
    </q-card-section>

    <q-card-section class="q-pt-none">
      <div class="text-teal">
        <b>
          {{
            preco?.toLocaleString('pt-br', {
              style: 'currency',
              currency: 'BRL',
            })
          }}</b
        >
      </div>
      <div class="text-caption text-grey">
        {{ descricao }}
      </div>
    </q-card-section>

    <q-card-actions class="row no-wrap justify-center">
      <q-btn
        outline
        unelevated
        class="text-center"
        color="teal"
        label="Adicionar no carinho"
      />
    </q-card-actions>
    <q-card-actions class="row no-wrap justify-center">
      <q-rating v-model="stars" color="teal" :max="5" size="32px" />
    </q-card-actions>
  </q-card>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';

import image from 'src/assets/foto-1.jpg';
import image2 from 'src/assets/foto-2.jpg';

export default defineComponent({
  name: 'IndexPage',
  components: {},
  props: {
    label: String,
    urlImage: String,
    preco: Number,
    descricao: String,
  },
  setup() {
    return {
      slide: ref(1),
      image,
      image2,
      stars: ref(Math.floor(Math.random() * 4) + 2),
    };
  },
});
</script>

<style lang="sass" scoped>
.my-card
  width: 100%
  max-width: 300px
</style>
