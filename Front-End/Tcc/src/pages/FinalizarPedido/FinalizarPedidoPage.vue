<template>
  <div class="row justify-center">
    <div class="q-pa-md col-lg-8 col-sm-11 col col-12">
      <q-stepper
        v-model="step"
        ref="stepper"
        animated
        active-color="teal"
        done-color="dark"
        active-icon="edit_note"
      >
        <q-step :done="step > 1" :name="1" prefix="1" title="Carinho"></q-step>
        <q-step :done="step > 2" :name="2" prefix="2" title="Login"></q-step>

        <q-step
          :done="step > 3"
          :name="3"
          prefix="3"
          title="Endereço"
          active-icon="where_to_vote"
        >
          <div class="q-pa-md q-gutter-md">
            <q-list
              bordered
              class="rounded-borders"
              style="min-width: 300px; max-width: 500px"
            >
              <q-item-label header>Confirmar Endereço</q-item-label>

              <q-item clickable v-ripple>
                <q-item-section avatar>
                  <q-icon name="pin_drop" />
                </q-item-section>
                <q-item-section class="col-sm-9 col-7">
                  <q-item-label>
                    <span class="text-weight-bold">CEP:</span>
                    74936-580
                  </q-item-label>
                  <q-item-label>
                    <span class="text-weight-bold">Rua:</span>
                    Avenida V 3
                  </q-item-label>
                  <q-item-label>
                    <span class="text-weight-bold">Numero:</span>
                    0
                  </q-item-label>
                  <q-item-label>
                    <span class="text-weight-bold">Bairro:</span>
                    Cidade Vera Cruz
                  </q-item-label>
                  <q-item-label>
                    <span class="text-weight-bold">Cidade:</span>
                    Aparecida de Goiânia
                  </q-item-label>
                  <q-item-label>
                    <span class="text-weight-bold">Estado:</span>
                    GO
                  </q-item-label>
                  <q-item-label>
                    <span class="text-weight-bold">Complemento:</span>
                    Teste 2
                  </q-item-label>
                </q-item-section>

                <q-item-section top side class="justify-center">
                  <q-btn
                    flat
                    color="teal"
                    icon="edit"
                    to="/usuario/enderecos"
                  />
                </q-item-section>
              </q-item>
            </q-list>
          </div>
        </q-step>

        <q-step :name="4" prefix="4" title="Finalizar"> </q-step>

        <template v-slot:navigation>
          <q-stepper-navigation>
            <q-btn
              v-if="step > 3"
              flat
              color="dark"
              @click="stepper.previous()"
              label="Voltar"
              icon="arrow_back_ios"
            />
            <q-btn
              class="q-ml-sm"
              @click="stepper.next()"
              color="teal"
              :label="step === 4 ? 'Finalizar' : 'Continue'"
            />
          </q-stepper-navigation>
        </template>
      </q-stepper>
    </div>
  </div>
</template>

<script lang="ts">
import { ref } from 'vue';
export default {
  name: 'FinalizarPedidoPage',
  setup() {
    return {
      step: ref(3),
      stepper: ref(),
    };
  },
};
</script>
