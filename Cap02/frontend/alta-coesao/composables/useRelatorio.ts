import { ref } from 'vue'
import type { Dado } from '@/types/Dado'
import { buscarDados, exportarCsv } from '@/services/relatorioService'
import { useProcessamento } from './useProcessamento'

export function useRelatorio() {
  const dados = ref<Dado[]>([])
  const total = ref(0)

  const { calcularTotal } = useProcessamento()

  const carregar = async () => {
    dados.value = await buscarDados()
    total.value = calcularTotal(dados.value)
  }

  const exportar = async () => {
    await exportarCsv(dados.value)
  }

  return {
    dados,
    total,
    carregar,
    exportar
  }
}