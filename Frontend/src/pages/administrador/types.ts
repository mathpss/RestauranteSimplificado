export interface IPedidoRetiradaHoje{
    nome: string,
    telefone: string,
    pedidos: IPedido[],
    
}

export interface IPedido{
   // id:number,
    valor: number,
    tamanho: string,
    guarnica: string[],
    mistura: string[],
    pedidoRetiradaId:number
}

export interface ICardapio{
    id: number,
    mistura: string,
    guarnicao: string
}