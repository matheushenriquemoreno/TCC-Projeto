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

        <!-- sessão usuario -->

        <q-item v-if="usuarioEstaLogado === false">
          <q-item-section side>
            <q-icon name="account_circle" color="teal" rounded size="48px" />
          </q-item-section>
          <q-item-section>
            <q-item-label>Olá, bem vindo(a)</q-item-label>
            <q-item-label
              @click="() => rotas.push('/login')"
              style="cursor: pointer"
              caption
              >Entrar / Cadastrar</q-item-label
            >
          </q-item-section>
        </q-item>
        <q-item v-else style="cursor: pointer">
          <q-item-section side>
            <q-avatar size="48px">
              <q-img :src="avatar" />
            </q-avatar>
          </q-item-section>
          <q-item-section>
            <q-btn flat dense>
              <div class="row items-center no-wrap">
                <div class="text-center text-overline">
                  Olá, {{ usuarioLogado?.nome }}
                </div>
                <q-icon name="expand_more" size="16px" class="q-ml-sm" />

                <q-menu auto-close>
                  <q-list dense>
                    <q-item class="GL__menu-link-signed-in">
                      <q-item-section>
                        <div>Seja Bem vindo!</div>
                      </q-item-section>
                    </q-item>
                    <q-separator />
                    <q-item
                      clickable
                      class="GL__menu-link"
                      to="/usuario/editar"
                    >
                      <q-item-section>
                        <div>
                          <q-icon name="person" />
                          Meu perfil
                        </div>
                      </q-item-section>
                    </q-item>
                    <q-item
                      clickable
                      class="GL__menu-link"
                      to="/usuario/pedidos"
                    >
                      <q-item-section>
                        <div>
                          <q-icon name="grading" />
                          Meus Pedidos
                        </div>
                      </q-item-section>
                    </q-item>
                    <q-item
                      clickable
                      class="GL__menu-link"
                      @click="() => storeUsuarioLogado.logout()"
                    >
                      <q-item-section>
                        <div>
                          <q-icon name="logout" />
                          Sair
                        </div>
                      </q-item-section>
                    </q-item>
                  </q-list>
                </q-menu>
              </div>
            </q-btn>
          </q-item-section>
        </q-item>
        <!-- fim -->
        <q-btn
          square
          flat
          size="19px"
          color="teal"
          icon="shopping_cart"
          @click="() => (showCarinho = !showCarinho)"
        >
          <template v-slot:default>
            <q-avatar class="q-ml-sm" color="teal" text-color="white">{{
              itensCarinho
            }}</q-avatar>
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
    <CarinhoCompras v-model:show-carinho="showCarinho" />
    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script lang="ts">
import useUsuarioLogado from 'src/stores/UsuarioLogadoStore';
import { computed, defineComponent, ref } from 'vue';
import { useRouter } from 'vue-router';
import CarinhoCompras from 'src/components/Carrinho/CarinhoCompras.vue';

import avatar from 'src/assets/avatar.jpg';
import { useCarinhoCompraStore } from 'src/stores/CarinhoCompraStore';

export default defineComponent({
  name: 'MainLayout',

  components: { CarinhoCompras },

  setup() {
    const carinhoStore = useCarinhoCompraStore();
    carinhoStore.obterCarinho();

    const text = ref('');
    const options = ref<any>();
    const filteredOptions = ref<any>([]);
    const search = ref<any>(null);
    const rotas = useRouter();
    const showCarinho = ref(false);
    const storeUsuarioLogado = useUsuarioLogado();

    const usuarioEstaLogado = computed(() =>
      storeUsuarioLogado.usuarioEstaLogado()
    );
    const itensCarinho = computed(() => carinhoStore.quantidadeItens);
    const usuarioLogado = computed(() => storeUsuarioLogado.obterUsuario());

    return {
      itensCarinho,
      avatar,
      usuarioLogado,
      usuarioEstaLogado,
      text,
      options,
      rotas,
      filteredOptions,
      search,
      showCarinho,
      storeUsuarioLogado,
    };
  },
});
</script>
