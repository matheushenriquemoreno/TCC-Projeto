<template>
  <q-dialog v-model="showCarinho" position="right" full-height>
    <q-card style="width: 400px; height: 100%">
      <q-card-section>
        <div class="text-h6 text-center text-teal">
          ITENS NO MEU CARRINHO (5)
        </div>
      </q-card-section>

      <q-separator />

      <q-card-section class="q-mt-sm">
        <p v-for="n in 2" :key="n">
          Lorem ipsum dolor sit amet consectetur adipisicing elit. Rerum
          repellendus sit voluptate voluptas eveniet porro. Rerum blanditiis
          perferendis totam, ea at omnis vel numquam exercitationem aut, natus
          minima, porro labore.
        </p>
      </q-card-section>

      <q-card-section class="q-mt-sm">
        <q-card class="my-card">
          <q-card-section class="text-center" style="height: 55px">
            <div class="text-weight-medium" style="font-size: 17px">
              Resumo do pedido
            </div>
          </q-card-section>
          <q-separator />
          <q-card-section class="text-center">
            <div class="row justify-between">
              <span class="text-subtitle1">Valor</span>
              <span class="text-green"><b>R$ 198,80</b></span>
            </div>
            <span class="text-subtitle1 text-weight-bold text-green"
              >Valor com 10% de desconto no boleto ou PIX</span
            >
          </q-card-section>
        </q-card>
      </q-card-section>

      <q-card-actions align="center">
        <q-btn
          icon="shopping_cart"
          label="Ir para o carinho"
          color="green"
          v-close-popup
        />
      </q-card-actions>
    </q-card>
  </q-dialog>
</template>

<script lang="ts">
import { computed, defineComponent, ref } from 'vue';

export default defineComponent({
  name: 'CarinhoCompras',

  components: {},

  setup() {
    const showCarinho = ref(false);

    // const fullName = computed({
    //   // getter
    //   get() {
    //     return firstName.value + ' ' + lastName.value;
    //   },
    //   // setter
    //   set(newValue) {
    //     // Note: we are using destructuring assignment syntax here.
    //     [firstName.value, lastName.value] = newValue.split(' ');
    //   },
    // });

    return {
      showCarinho,
    };
  },
});
</script>
