<template>
  <q-page class="row">
    <div class="col-12 text-center">
      <div class="q-pa-sm rounded-1 q-mb-sm">
        <q-carousel
          animated
          v-model="slide"
          arrows
          navigation
          infinite
          style="height: 400px"
        >
          <q-carousel-slide
            :name="1"
            img-src="https://imgcentauro-a.akamaihd.net/05_Campanhas/2024/SeuEsporte/primaria/desk_reduzido.jpg"
          />
          <q-carousel-slide :name="2" :img-src="image" />
          <q-carousel-slide :name="3" :img-src="image2" />
        </q-carousel>
      </div>
      <span class="text-h4"> Aproveite as melhores ofertas</span>
    </div>
  </q-page>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';

import image from 'src/assets/foto-1.jpg';
import image2 from 'src/assets/foto-2.jpg';
import { useRouter } from 'vue-router';

export default defineComponent({
  name: 'IndexPage',
  components: {},
  setup() {
    const rotas = useRouter();

    return {
      slide: ref(1),
      rotas,
      image,
      image2,
    };
  },
});
</script>
