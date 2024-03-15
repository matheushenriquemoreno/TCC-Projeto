<template>
  <div class="page">
    <div class="container">
      <div class="left">
        <div class="login">Login</div>
        <div class="eula">
          Seja bem vindo(a), realize seu login para continuar.
        </div>
      </div>
      <div class="right row">
        <div class="col-12">
          <q-form class="row justify-center q-mt-lg">
            <q-input
              filled
              class="col-11 q-mt-sm"
              v-model="email"
              label="E-mail"
              lazy-rules
              :rules="[
                (val) => (val && val.length > 0) || 'Please type something',
              ]"
            />

            <q-input
              class="col-11 q-mt-sm"
              label="Senha * (8 ou mais caracteres)"
              v-model="senha"
              filled
              lazy-rules
              :type="isPwd ? 'password' : 'text'"
              :rules="[
                (val) => (val && val.length > 0) || 'Please type something',
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
            <q-btn class="col-11 q-mt-lg" color="grey" label="Logar" />

            <span
              class="text-dark text-center col-11 q-mt-lg"
              style="cursor: pointer"
              >Ainda não possui conta?</span
            >
          </q-form>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';

import logo from 'src/assets/Logo-4.jpg';
import { useRouter } from 'vue-router';
import { log } from 'console';

export default defineComponent({
  name: 'IndexPage',
  components: {},
  setup() {
    const rotas = useRouter();
    const email = ref(null);
    const senha = ref(null);

    return {
      logo,
      isPwd: ref(true),
      email,
      senha,
    };
  },
});
</script>

<style scoped>
@import url('https://rsms.me/inter/inter-ui.css');

.page {
  background: #e2e2e5;
  display: flex;
  flex-direction: column;
  height: calc(100%);
  position: absolute;
  place-content: center;
  width: calc(100%);
}
@media (max-width: 767px) {
  .page {
    height: auto;
    margin-bottom: 20px;
    padding-bottom: 20px;
  }
}
.container {
  display: flex;
  height: 320px;
  margin: 0 auto;
  width: 640px;
}
@media (max-width: 767px) {
  .container {
    flex-direction: column;
    height: 630px;
    width: 320px;
  }
}
.left {
  background: white;
  height: calc(100% - 40px);
  top: 20px;
  position: relative;
  width: 50%;
}
@media (max-width: 767px) {
  .left {
    height: 100%;
    left: 20px;
    width: calc(100% - 40px);
    max-height: 270px;
  }
}
.login {
  font-size: 50px;
  font-weight: 900;
  margin: 50px 40px 40px;
}
.eula {
  color: #999;
  font-size: 14px;
  line-height: 1.5;
  margin: 40px;
}
.right {
  background: #fafafa;
  box-shadow: 0px 0px 40px 16px rgba(0, 0, 0, 0.22);
  color: #f1f1f2;
  position: relative;
  width: 50%;
}
@media (max-width: 767px) {
  .right {
    flex-shrink: 0;
    height: 100%;
    width: 100%;
    max-height: 350px;
  }
}
path {
  fill: none;
  stroke: url(#linearGradient);
  stroke-width: 4;
  stroke-dasharray: 240 1386;
}
</style>
