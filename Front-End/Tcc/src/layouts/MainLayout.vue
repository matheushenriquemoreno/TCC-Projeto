<template>
  <q-layout>
    <q-header
      bordered
      class="text-dark"
      style="background: #fff; max-height: 500px"
    >
      <!--Page parte 1-->
      <q-toolbar class="q-pa-sm row justify-center">
        <q-select
          style="width: 290px; border-radius: 20px"
          label="O que deseja procurar?"
          color="dark"
          outlined
          dense
          v-model="text"
          :options="options"
        >
          <template v-slot:append>
            <q-icon name="search" color="teal" />
          </template>
        </q-select>
        <q-item>
          <q-item-section side>
            <q-icon name="account_circle" color="teal" rounded size="48px" />
          </q-item-section>
          <q-item-section>
            <q-item-label>Olá, bem vindo(a)</q-item-label>
            <q-item-label
              @click="() => console.log('teste')"
              style="cursor: pointer"
              caption
              >Entrar / Cadastrar</q-item-label
            >
          </q-item-section>
        </q-item>
        <q-btn square flat size="19px" color="teal" icon="shopping_cart">
          <template v-slot:default>
            <q-avatar class="q-ml-sm" color="teal" text-color="white"
              >1</q-avatar
            >
          </template>
        </q-btn>
      </q-toolbar>
      <!--Page parte 2-->
      <q-toolbar class="row justify-center q-gutter-x-xl">
        <q-btn flat dense push @click="() => rotas.push('/produtos/21')">
          <div class="row items-center no-wrap">
            <q-icon left name="sports_tennis" color="teal" />
            <div class="text-center text-overline">beach tennis</div>
          </div>
        </q-btn>

        <!---->
        <q-btn flat dense push @click="() => rotas.push('/produtos/22')">
          <div class="row items-center no-wrap">
            <q-icon left name="sports_soccer" color="teal" />
            <div class="text-center text-overline">Futebol</div>
          </div>
        </q-btn>
        <!---->
        <q-btn flat dense push @click="() => rotas.push('/produtos/23')">
          <div class="row items-center no-wrap">
            <q-icon left name="directions_bike" color="teal" />
            <div class="text-center text-overline">Ciclismo</div>
          </div>
        </q-btn>
        <!---->
        <q-btn flat dense push>
          <div class="row items-center no-wrap">
            <div class="text-center text-overline">Outro esportes</div>
            <q-icon name="expand_more" size="16px" class="q-ml-sm" />

            <q-menu auto-close>
              <q-list dense>
                <q-item class="GL__menu-link-signed-in">
                  <q-item-section>
                    <div>Seja Bem vindo! <strong>Matheus</strong></div>
                  </q-item-section>
                </q-item>
                <q-separator />
                <q-item clickable class="GL__menu-link-status">
                  <q-item-section>
                    <div>
                      <q-icon name="tag_faces" color="blue-9" size="18px" />
                      Set your status
                    </div>
                  </q-item-section>
                </q-item>
                <q-separator />
                <q-item clickable class="GL__menu-link">
                  <q-item-section>Your profile</q-item-section>
                </q-item>
                <q-item clickable class="GL__menu-link">
                  <q-item-section>Your repositories</q-item-section>
                </q-item>
                <q-item clickable class="GL__menu-link">
                  <q-item-section>Your projects</q-item-section>
                </q-item>
                <q-item clickable class="GL__menu-link">
                  <q-item-section>Your stars</q-item-section>
                </q-item>
                <q-item clickable class="GL__menu-link">
                  <q-item-section>Your gists</q-item-section>
                </q-item>
                <q-separator />
                <q-item clickable class="GL__menu-link">
                  <q-item-section>Help</q-item-section>
                </q-item>
                <q-item clickable class="GL__menu-link">
                  <q-item-section>Settings</q-item-section>
                </q-item>
                <q-item clickable class="GL__menu-link">
                  <q-item-section>Sign out</q-item-section>
                </q-item>
              </q-list>
            </q-menu>
          </div>
        </q-btn>
      </q-toolbar>
    </q-header>

    <!--Carinho -->



    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { useRouter } from 'vue-router';

export default defineComponent({
  name: 'MainLayout',

  components: {},

  setup() {
    const text = ref('');
    const options = ref<any>();
    const filteredOptions = ref<any>([]);
    const search = ref<any>(null); // $refs.search
    const rotas = useRouter();
    const showCarinho = ref(true);

    return {
      text,
      options,
      rotas,
      filteredOptions,
      search,
      showCarinho,
    };
  },
});
</script>
