<template>
  <q-card>
    <div class="q-pa-md q-gutter-sm"><q-icon name="person" /> Minha Conta</div>
    <q-card-section>
      <q-form class="row justify-center q-gutter-sm">
        <div class="col-11">
          <q-input
            outlined
            v-model="clienteUpdate.nomeCompleto"
            label="nomeCompleto"
          />
        </div>
        <div class="col-11">
          <q-input outlined v-model="clienteUpdate.cpf" label="CPF" />
        </div>
        <div class="col-11">
          <q-input
            outlined
            v-model="clienteUpdate.email"
            label="email"
            :rules="rulesEmail"
          />
        </div>
        <div class="col-11">
          <q-input
            outlined
            v-model="clienteUpdate.dataNascimento"
            label="dataNascimento"
          />
        </div>
        <div class="col-11">
          <q-input outlined v-model="clienteUpdate.telefone" label="telefone" />
        </div>
      </q-form>
    </q-card-section>
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

<style scoped>
.page {
  background: #e2e2e5;
  height: calc(100%);
  place-content: center;
  width: calc(100%);
}
</style>
