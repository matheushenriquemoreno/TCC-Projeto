import { RouteRecordRaw } from 'vue-router';

const routes: RouteRecordRaw[] = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      {
        path: '',
        name: 'IndexPage',
        component: () => import('pages/IndexPage.vue'),
      },
      {
        path: '/produtos/:IdCategoria',
        component: () => import('src/pages/produtos.vue'),
      },
      {
        path: '/CarinhoCompra',
        component: () => import('src/pages/CarinhoCompraPage.vue'),
      },

      {
        path: '/usuario',
        component: () => import('src/pages/Usuario/GuiaUsuario.vue'),
        children: [
          {
            path: 'editar',
            name: 'EditarCliente',
            component: () => import('src/pages/Usuario/EditarUsuario.vue'),
          },
          {
            path: 'pedidos',
            name: 'pedidos',
            component: () => import('src/pages/Usuario/UsuarioPedidos.vue'),
          },
          {
            path: 'enderecos',
            name: 'enderecos',
            component: () => import('src/pages/Usuario/UsuarioEnderecos.vue'),
          },
        ],
      },
    ],
  },

  {
    path: '/login',
    component: () => import('pages/Login/LoginPage.vue'),
  },
  {
    path: '/',
    component: () => import('layouts/UserLayout.vue'),
    children: [
      {
        path: 'cadastro',
        component: () => import('pages/Login/CadastroLoginUsuario.vue'),
      },
      {
        path: '/FinalizarPedido',
        component: () =>
          import('src/pages/FinalizarPedido/FinalizarPedidoPage.vue'),
      },
    ],
  },
  {
    path: '/admin',
    component: () => import('layouts/AdminLayout.vue'),
    children: [{ path: '', component: () => import('pages/IndexPage.vue') }],
  },
  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/ErrorNotFound.vue'),
  },
];

export default routes;
