import { RouteRecordRaw } from 'vue-router';

const routes: RouteRecordRaw[] = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: '', component: () => import('pages/IndexPage.vue') },
      {
        path: '/produtos/:IdCategoria',
        component: () => import('src/pages/produtos.vue'),
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
