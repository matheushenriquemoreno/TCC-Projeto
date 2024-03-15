import { defineStore } from 'pinia';

export const useCarinhoCompraStore = defineStore('CarinhoCompraStore', {
  state: () => ({
    counter: 0,
  }),
  getters: {
    doubleCount: (state) => state.counter * 2,
  },
  actions: {
    increment() {
      this.counter++;
    },
  },
});
