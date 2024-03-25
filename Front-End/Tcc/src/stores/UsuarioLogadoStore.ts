import { defineStore } from 'pinia';
import { UserLogado } from 'src/services/interfaces/Cliente';

function obterUsuarioLocalStorage() {
  const user = localStorage.getItem('User');

  if (user) {
    return JSON.parse(user) as UserLogado;
  }
  return null;
}

const useUsuarioLogado = defineStore('UsuarioLogado', {
  state: () => ({
    usuario: {} as UserLogado,
  }),
  actions: {
    inserirUsuario(user: UserLogado) {
      localStorage.setItem('User', JSON.stringify(user));
    },
    obterUsuario() {
      const usuario = obterUsuarioLocalStorage();
      if (usuario) {
        this.usuario = usuario;
        return this.usuario;
      }
      return null;
    },
    usuarioEstaLogado() {
      const usuario = obterUsuarioLocalStorage();
      if (usuario != null && usuario.token.length > 0) {
        return true;
      }
      return false;
    },
    logout() {
      localStorage.removeItem('User');
      localStorage.clear();
    },
  },
});

export default useUsuarioLogado;
