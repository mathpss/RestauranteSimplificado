export interface ILocation {
    mistura: string[],
    guarnicao: string[]
}

export interface IEndereco {
    nomeRua?: string,
    numeroRua?: string,
    bairro?: string,
    cidade?: string,
}

export interface IPedido {
    pedido: number,
    mistura: string[],
    guarnicao: string[],
    tamanho: string,
    valor: number
}