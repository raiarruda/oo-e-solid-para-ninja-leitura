import axios from 'axios'
import type { Dado } from '@/types/Dado'

export async function buscarDados(): Promise<Dado[]> {
  const { data } = await axios.get('/dados')
  return data
}

export async function exportarCsv(dados: Dado[]) {
  const csv = dados.map(d => d.valor).join(',')
  console.log(csv)
}