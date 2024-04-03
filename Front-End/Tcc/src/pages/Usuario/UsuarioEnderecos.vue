<template>
  <q-card flat>
    <div class="q-pa-md q-gutter-sm">
      <q-breadcrumbs class="text-dark" active-color="dark">
        <template v-slot:separator>
          <q-icon size="1.2em" name="arrow_forward" color="teal" />
        </template>
        <q-breadcrumbs-el label="Usuário" />
        <q-breadcrumbs-el label="Endereço" icon="pin_drop" />
      </q-breadcrumbs>
    </div>
    <q-form @submit.prevent.stop="onSubmit">
      <q-card-section>
        <div class="row">
          <div class="col-sm-4 col-12 q-pa-sm">
            <q-input
              :rules="[
                (val) => (val && val.length === 8) || 'Campo Obrigatorio!',
              ]"
              lazy-rules
              v-model="Endereco.cep"
              label="Cep"
              mask="#####-###"
              unmasked-value
              :loading="loadingBuscarCep"
              @update:model-value="(value) => buscarCep(value)"
            >
              <template v-slot:prepend>
                <q-icon name="pin_drop" />
              </template>
            </q-input>
          </div>
          <div class="col-sm-4 col-12 q-pa-sm">
            <q-input
              v-model="Endereco.rua"
              label="Rua"
              readonly
              :loading="loadingBuscarCep"
            />
          </div>
          <div class="col-sm-2 col-12 q-pa-sm">
            <q-input
              v-model.number="Endereco.numero"
              type="number"
              label="Numero"
            />
          </div>
          <div class="col-sm-4 col-12 q-pa-sm">
            <q-input
              v-model="Endereco.bairro"
              label="Bairro"
              readonly
              :loading="loadingBuscarCep"
            />
          </div>
          <div class="col-sm-4 col-12 q-pa-sm">
            <q-input
              v-model="Endereco.cidade"
              label="Cidade"
              readonly
              :loading="loadingBuscarCep"
            />
          </div>
          <div class="col-sm-2 col-12 q-pa-sm">
            <q-input
              v-model="Endereco.estado"
              label="Estado"
              readonly
              :loading="loadingBuscarCep"
            />
          </div>
          <div class="col-sm-4 col-12 q-pa-sm">
            <q-input
              v-model="Endereco.complemento"
              label="Complemento"
              autogrow
            />
          </div>
        </div>
      </q-card-section>

      <q-card-actions align="right">
        <q-btn
          class="q-mb-sm"
          label="Salvar"
          icon="save"
          color="teal"
          type="submit"
        />
      </q-card-actions>
    </q-form>
    <q-inner-loading :showing="loadingUsuario">
      <q-spinner-gears size="50px" color="teal" />
    </q-inner-loading>
  </q-card>
</template>

<script lang="ts">
import { useQuasar } from 'quasar';
import ObterServiceCliente from 'src/services/serviceCliente';
import useUsuarioLogado from 'src/stores/UsuarioLogadoStore';
import { defineComponent, onMounted, ref } from 'vue';

interface dadosEnderecoViaCep {
  cep: string;
  logradouro: string;
  complemento: string;
  bairro: string;
  localidade: string;
  uf: string;
  ibge: string;
  gia: string;
  ddd: string;
  siafi: string;
}

export default defineComponent({
  name: 'UsuarioEnderecos',
  components: {},
  setup() {
    const $q = useQuasar();
    const usuarioLogadoStore = useUsuarioLogado();
    const serviceUsuario = ObterServiceCliente();
    const loadingBuscarCep = ref(false);
    const loadingUsuario = ref(false);
    const Endereco = ref({
      idCliente: usuarioLogadoStore.obterUsuario()?.idCliente,
      cep: '',
      rua: '',
      numero: 0,
      bairro: '',
      cidade: '',
      estado: '',
      complemento: '',
    });

    async function buscarCep(cep: string | null | number) {
      if (cep && cep.toString().length >= 8) {
        loadingBuscarCep.value = true;
        const request = await fetch(`https://viacep.com.br/ws/${cep}/json/`);
        const result = (await request.json()) as dadosEnderecoViaCep;

        Endereco.value.rua = result.logradouro;
        Endereco.value.bairro = result.bairro;
        Endereco.value.cidade = result.localidade;
        Endereco.value.estado = result.uf;
        loadingBuscarCep.value = false;
      }
    }

    onMounted(async () => {
      const usuarioLogado = usuarioLogadoStore.obterUsuario();
      if (usuarioLogado) {
        loadingUsuario.value = true;
        const cliente = await serviceUsuario.obterPeloId(
          usuarioLogado.idCliente
        );
        if (cliente.endereco) {
          Endereco.value.rua = cliente.endereco.rua;
          Endereco.value.bairro = cliente.endereco.bairro;
          Endereco.value.cidade = cliente.endereco.cidade;
          Endereco.value.estado = cliente.endereco.estado;
          Endereco.value.cep = cliente.endereco.cep;
          Endereco.value.numero = cliente.endereco.numero;
          Endereco.value.complemento = cliente.endereco.complemento;
        }
        loadingUsuario.value = false;
      }
    });

    async function onSubmit() {
      await serviceUsuario.cadastrarEnderecoCliente(Endereco.value);
      $q.notify({
        message: 'Atualização de endereço realizada com sucesso!',
        type: 'positive',
      });
    }

    return { Endereco, buscarCep, loadingBuscarCep, onSubmit, loadingUsuario };
  },
});
</script>
