<template>
  <div class="row justify-center q-mt-lg">
    <div class="q-pa-md col-lg-8 col-sm-11 col col-12">
      <q-stepper
        v-model="step"
        ref="stepper"
        animated
        active-color="teal"
        done-color="dark"
        active-icon="edit_note"
        class="q-pa-lg shadowPayment"
      >
        <q-step :done="step > 1" :name="1" prefix="1" title="Login"></q-step>
        <q-step :done="step > 2" :name="2" prefix="2" title="Carrinho"></q-step>

        <q-step
          :done="step > 3"
          :name="3"
          prefix="3"
          title="Endereço"
          active-icon="where_to_vote"
        >
          <div class="q-pa-md q-gutter-md">
            <q-list bordered class="rounded-borders">
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

        <q-step :name="4" prefix="4" title="Finalizar">
          <div class="row justify-center">
            <div class="col-12 q-pa-md">
              <div class="row justify-center">
                <div class="col-md-7 col-12 q-pa-sm">
                  <q-list padding>
                    <q-item-label
                      header
                      class="text-dark"
                      style="font-size: 17px"
                    >
                      <q-icon name="credit_card" size="sm" color="brown-6" />
                      Métodos de Pagamento</q-item-label
                    >

                    <q-item class="bg-grey-4" tag="label" v-ripple>
                      <q-item-section side top>
                        <q-radio v-model="pagamento" :val="1" />
                      </q-item-section>

                      <q-item-section>
                        <q-item-label>Pague via pix</q-item-label>
                        <q-item-label caption>
                          O QR Code para pagamento será gerado após a conclusão
                          do pedido.
                        </q-item-label>
                      </q-item-section>
                    </q-item>

                    <q-item tag="label" class="bg-grey-4 q-mt-sm" v-ripple>
                      <q-item-section side top>
                        <q-radio v-model="pagamento" :val="2" />
                      </q-item-section>

                      <q-item-section>
                        <q-item-label>Boleto Bancário</q-item-label>
                      </q-item-section>
                    </q-item>
                  </q-list>
                </div>
                <div class="col-md-5 col-12 q-pa-sm">
                  <q-card class="my-card q-mb-sm" flat bordered>
                    <q-item>
                      <q-item-section class="text-center">
                        <q-item-label class="text-h6">Resumo</q-item-label>
                      </q-item-section>
                    </q-item>

                    <q-separator />

                    <q-card-section class="text-center">
                      <div class="row justify-between q-mb-sm">
                        <span class="text-subtitle1">Subtotal</span>
                        <span class="text-dark"
                          ><b>{{
                            carinho.valorTotal.toLocaleString('pt-br', {
                              style: 'currency',
                              currency: 'BRL',
                            })
                          }}</b></span
                        >
                      </div>
                      <div class="row justify-between q-mb-sm">
                        <span class="text-subtitle1">Desconto</span>
                        <span class="text-dark"
                          ><b>{{
                            desconto.toLocaleString('pt-br', {
                              style: 'currency',
                              currency: 'BRL',
                            })
                          }}</b></span
                        >
                      </div>
                      <div class="row justify-between q-mb-sm">
                        <span class="text-subtitle1">Frete padrão</span>
                        <span class="text-dark"
                          ><b>{{
                            valorFretePadrao.toLocaleString('pt-br', {
                              style: 'currency',
                              currency: 'BRL',
                            })
                          }}</b></span
                        >
                      </div>
                      <div class="row justify-between q-mb-sm">
                        <span class="text-subtitle1">Total</span>
                        <span class="text-green"
                          ><b>{{
                            total.toLocaleString('pt-br', {
                              style: 'currency',
                              currency: 'BRL',
                            })
                          }}</b></span
                        >
                      </div>
                    </q-card-section>
                  </q-card>
                </div>
              </div>
            </div>
          </div>
        </q-step>

        <template v-slot:navigation>
          <q-stepper-navigation
            :class="step === 4 ? 'row justify-between' : ''"
          >
            <q-btn
              v-if="step >= 3"
              flat
              color="dark"
              @click="
                () => {
                  if (step === 3) {
                    router.push('/CarinhoCompra');
                  } else {
                    stepper.previous();
                  }
                }
              "
              label="Voltar"
              icon="arrow_back_ios"
            />
            <q-btn
              class="q-ml-sm"
              @click="stepper.next()"
              color="teal"
              :label="step === 4 ? 'Finalizar Pagamento' : 'Continue'"
            />
          </q-stepper-navigation>
        </template>
      </q-stepper>
    </div>
  </div>
</template>

<script lang="ts">
import { computed, onMounted, onUpdated, ref } from 'vue';
import { useCarinhoCompraStore } from 'src/stores/CarinhoCompraStore';
import { useRouter } from 'vue-router';
export default {
  name: 'FinalizarPedidoPage',
  setup() {
    const router = useRouter();
    const carinhoStore = useCarinhoCompraStore();

    onMounted(async () => {
      await carinhoStore.obterCarinho();
    });

    onUpdated(async () => {
      await carinhoStore.obterCarinho();
    });

    const carinho = computed(() => carinhoStore.carinho);
    const pagamento = ref(1);
    const valorFretePadrao = 30;
    const desconto = computed(() => {
      return carinho.value.valorTotal * 0.1;
    });
    const total = computed(() => {
      return carinho.value.valorTotal - desconto.value + valorFretePadrao;
    });

    return {
      step: ref(3),
      stepper: ref(),
      carinho,
      pagamento,
      valorFretePadrao,
      desconto,
      total,
      router,
    };
  },
};
</script>

<style scoped>
.shadowPayment {
  box-shadow: rgba(17, 17, 26, 0.1) 0px 4px 16px,
    rgba(17, 17, 26, 0.1) 0px 8px 24px, rgba(17, 17, 26, 0.1) 0px 16px 56px;
}
</style>
