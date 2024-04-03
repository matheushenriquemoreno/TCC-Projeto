import axios, { AxiosInstance } from 'axios';

export default function obterAxios(url: string): AxiosInstance {
  const api = axios.create({
    baseURL: `${url}`,
    timeout: 1000,
  });

  return api;
}
