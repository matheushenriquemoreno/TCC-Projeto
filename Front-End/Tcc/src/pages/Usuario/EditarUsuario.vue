<template>
  <q-card flat>
    <div class="q-pa-md q-gutter-sm">
      <q-breadcrumbs class="text-dark" active-color="dark">
        <template v-slot:separator>
          <q-icon size="1.2em" name="arrow_forward" color="teal" />
        </template>
        <q-breadcrumbs-el label="Usuário" />
        <q-breadcrumbs-el label="Dados" icon="pin_drop" />
      </q-breadcrumbs>
    </div>
    <q-form>
      <q-card-section>
        <div class="row">
          <div class="col-sm-12 col-12 q-pa-sm">
            <q-input v-model="clienteUpdate.nomeCompleto" label="Nome" />
          </div>
          <div class="col-sm-6 col-12 q-pa-sm">
            <q-input v-model="clienteUpdate.cpf" label="CPF" />
          </div>
          <div class="col-sm-6 col-12 q-pa-sm">
            <q-input
              v-model="clienteUpdate.email"
              label="E-mail"
              :rules="rulesEmail"
            />
          </div>
          <div class="col-sm-4 col-12 q-pa-sm">
            <q-input
              v-model="clienteUpdate.dataNascimento"
              label="Data Nascimento"
            />
          </div>
          <div class="col-sm-4 col-12 q-pa-sm">
            <q-input v-model="clienteUpdate.telefone" label="Telefone" />
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
  </q-card>
</template>

<script lang="ts">
import { Cliente } from 'src/services/interfaces/Cliente';
import ObterServiceCliente from 'src/services/serviceCliente';
import useUsuarioLogado from 'src/stores/UsuarioLogadoStore';
import { defineComponent, onMounted, ref } from 'vue';
import { useRouter } from 'vue-router';

export default defineComponent({
  name: 'EditarUsuario',
  components: {},
  setup() {
    const usuarioLogadoStore = useUsuarioLogado();
    const clienteService = ObterServiceCliente();
    const router = useRouter();
    const clienteUpdate = ref({
      email: '',
      cpf: '',
      nomeCompleto: '',
      dataNascimento: '',
      telefone: '',
      genero: '',
    });

    const validaEmail = (email: string) => {
      return /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(
        email
      );
    };

    onMounted(async () => {
      const cliente = await clienteService.obterPeloId(
        usuarioLogadoStore.obterUsuario()?.idCliente ?? 0
      );
      console.log(cliente);
    });

    const rules = [
      (val: any) => (val && val.length > 0) || 'Campo obrigatorio',
    ];
    const rulesEmail = [
      (val: string) => (val && val.length > 0) || 'Campo obrigatorio',
      (val: string) => validaEmail(val) || 'Digite um e-mail Valido',
    ];
    return {
      clienteUpdate,
      router,
      rules,
      rulesEmail,
    };
  },
});
</script>
