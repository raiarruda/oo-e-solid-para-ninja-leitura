import type { Dado } from '@/types/Dado'

export function useProcessamento() {
  const calcularTotal = (dados: Dado[]) => {
    return dados.reduce((acc, d) => acc + d.valor * 2, 0)
  }

  return { calcularTotal }
}