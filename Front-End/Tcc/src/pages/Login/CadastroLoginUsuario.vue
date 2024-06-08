<template>
  <q-page class="page">
    <div class="row justify-center">
      <q-card class="my-card q-mt-lg" bordered style="width: 400px">
        <q-card-section class="text-center bg-grey-2">
          <div><b>Identificação</b></div>
        </q-card-section>
        <q-form @submit="onSubmit">
          <q-card-section>
            <div><b>Dados Pessoais</b></div>
            <div class="row justify-center q-mt-md q-gutter-md">
              <div class="col-11">
                <q-input
                  square
                  outlined
                  type="email"
                  v-model="usuario.email"
                  label="E-mail *"
                  lazy-rules
                  :rules="rulesEmail"
                >
                </q-input>
              </div>
              <div class="col-11">
                <q-input
                  square
                  outlined
                  v-model="usuario.cpf"
                  label="CPF *"
                  lazy-rules
                  placeholder="###.###.###-##"
                  mask="###.###.###-##"
                  :rules="[
                    (val) => (val && val.length >= 11) || 'Campo obrigatorio',
                  ]"
                  unmasked-value
                />
              </div>
              <div class="col-11">
                <q-input
                  square
                  outlined
                  v-model="usuario.nome"
                  label="Nome completo *"
                  :rules="rules"
                />
              </div>
              <div class="col-11">
                <q-input
                  square
                  outlined
                  v-model="usuario.dataNascimento"
                  label="Data de nascimento*"
                  :rules="[
                    (val) => (val && val.length >= 10) || 'Campo obrigatorio',
                  ]"
                  lazy-rules
                  mask="##/##/####"
                  placeholder="dia/mês/ano"
                />
              </div>
              <div class="col-11">
                <q-input
                  square
                  outlined
                  v-model="usuario.telefone"
                  label="Telefone celular *"
                  :rules="[
                    (val) => (val && val.length >= 11) || 'Campo obrigatorio',
                  ]"
                  placeholder="(##) ##### - ####"
                  lazy-rules
                  mask="(##) ##### - ####"
                />
              </div>
              <div class="col-11 q-mb-sm q-mt-none">
                <span>Gênero</span>
                <div class="q-gutter-x-md">
                  <q-radio
                    dense
                    v-model="usuario.genero"
                    color="teal"
                    :val="1"
                    label="Masculino"
                  />
                  <q-radio
                    color="teal"
                    dense
                    v-model="usuario.genero"
                    :val="2"
                    label="Feminino"
                  />
                  <q-radio
                    dense
                    color="teal"
                    v-model="usuario.genero"
                    :val="3"
                    label="Outro"
                  />
                </div>
              </div>
              <div class="col-11">
                <q-input
                  label="Senha * (8 ou mais caracteres)"
                  v-model="usuario.senha"
                  square
                  lazy-rules
                  outlined
                  :type="isPwd ? 'password' : 'text'"
                  :rules="[
                    (val) => (val && val.length >= 8) || 'Campo obrigatorio',
                    (val) =>
                      (val &&
                        val.length >= 8 &&
                        verificarForcaSenha(val) == 1) ||
                      'Necessario uma senha forte',
                  ]"
                >
                  <template v-slot:append>
                    <q-icon
                      :name="isPwd ? 'visibility_off' : 'visibility'"
                      class="cursor-pointer"
                      @click="isPwd = !isPwd"
                    />
                  </template>
                </q-input>
                <div
                  class="q-mt-sm"
                  v-if="usuario.senha && usuario.senha.length > 0"
                >
                  <q-linear-progress
                    :value="forcaSenha"
                    class="q-mt-none"
                    style="margin-bottom: 2px"
                    :color="corProgressoSenha"
                    size="8px"
                    rounded
                  />
                  <span> Nivel de segurança</span>
                </div>
              </div>
            </div>
          </q-card-section>

          <q-card-actions align="center" vertical class="q-mb-lg">
            <q-btn
              label="Cadastrar"
              color="green"
              type="submit"
              style="width: 75%"
            />
            <span
              class="text-dark text-center col-11 q-mt-lg"
              style="cursor: pointer"
              @click="router.push('/Login')"
              >Já possui conta?</span
            >
          </q-card-actions>
        </q-form>
      </q-card>
    </div>
  </q-page>
</template>

<script lang="ts">
import { useQuasar } from 'quasar';
import { Cliente } from 'src/services/interfaces/Cliente';
import ObterServiceCliente from 'src/services/serviceCliente';
import useUsuarioLogado from 'src/stores/UsuarioLogadoStore';
import { computed, defineComponent, ref } from 'vue';
import { useRouter } from 'vue-router';

function verificarForcaSenha(senha: string): number {
  // Verificar comprimento mínimo
  if (senha.length < 8) {
    return 0; // Muito fraca
  }

  // Verificar se contém letras maiúsculas, minúsculas, números e caracteres especiais
  const possuiLetraMaiuscula = /[A-Z]/.test(senha);
  const possuiLetraMinuscula = /[a-z]/.test(senha);
  const possuiNumero = /[0-9]/.test(senha);
  const possuiCaractereEspecial = /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/.test(
    senha
  );

  let forca = 0.2;
  if (possuiLetraMaiuscula) forca = forca + 0.2;
  if (possuiLetraMinuscula) forca = forca + 0.2;
  if (possuiNumero) forca = forca = forca + 0.2;
  if (possuiCaractereEspecial) forca = forca + 0.2;

  return forca; // Retorna um valor entre 0.2 a 1, indicando a força da senha
}

function converterDataBRParaDate(dataBR: string) {
  // Divide a string da data em dia, mês e ano
  var partes = dataBR.split('/');

  // Certifica-se de que temos 3 partes (dia, mês, ano)
  if (partes.length !== 3) {
    throw new Error('Formato de data inválido. Use o formato dia/mês/ano.');
  }

  // Obtém dia, mês e ano
  var dia = parseInt(partes[0], 10);
  var mes = parseInt(partes[1], 10) - 1; // Mês é base 0 no Date, então subtrai 1
  var ano = parseInt(partes[2], 10);

  // Cria um objeto Date com os valores obtidos
  var data = new Date(ano, mes, dia);

  return data;
}

export default defineComponent({
  name: 'CadastroUsuario',
  components: {},
  setup() {
    const usuario = ref({
      email: '',
      cpf: '',
      nome: '',
      dataNascimento: '',
      telefone: '',
      genero: '',
      senha: '',
    });

    const service = ObterServiceCliente();
    const router = useRouter();
    const $q = useQuasar();

    const usuarioLogadoStore = useUsuarioLogado();

    async function onSubmit() {
      const clienteAdicionar: Cliente = {
        cpf: usuario.value.cpf,
        email: usuario.value.email,
        genero: parseInt(usuario.value.genero),
        nomeCompleto: usuario.value.nome,
        telefone: usuario.value.telefone,
        senha: usuario.value.senha,
        dataNascimento: converterDataBRParaDate(usuario.value.dataNascimento),
      };

      const result = await service.cadastrarCliente(clienteAdicionar);

      if (result) {
        $q.notify({
          message: 'Cadastro realizado com sucesso!',
          caption: 'Bem vindo(a)',
          type: 'positive',
        });

        usuarioLogadoStore.inserirUsuario(result);
        router.push({ name: 'IndexPage' });
      }
    }

    const validaEmail = (email: string) => {
      return /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(
        email
      );
    };

    const forcaSenha = computed(() => {
      return verificarForcaSenha(usuario.value.senha);
    });

    const corProgressoSenha = computed(() => {
      if (forcaSenha.value < 1 && forcaSenha.value >= 0.5) return 'warning';
      if (forcaSenha.value === 1) return 'green';
      return 'red';
    });

    const rules = [
      (val: any) => (val && val.length > 0) || 'Campo obrigatorio',
    ];
    const rulesEmail = [
      (val: string) => (val && val.length > 0) || 'Campo obrigatorio',
      (val: string) => validaEmail(val) || 'Digite um e-mail Valido',
    ];
    return {
      verificarForcaSenha,
      onSubmit,
      usuario,
      router,
      isPwd: ref(true),
      rules,
      rulesEmail,
      forcaSenha,
      corProgressoSenha,
    };
  },
});
</script>

<style scoped>
.page {
  background: #e2e2e5;
  height: calc(100%);
  width: calc(100%);
}
</style>
