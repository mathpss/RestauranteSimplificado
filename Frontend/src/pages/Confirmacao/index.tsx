import { useLocation } from "react-router-dom"
import { Container, Wrapper } from "./styles"
import { IPedido, IEndereco } from "./types"
import Button from "../../components/Button"
import { useState } from "react"
import { api } from "../../services/Api"


export const Confirmacao = () => {
    const { state } = useLocation()

    const { listaPedido, endereco, isChecked }: { listaPedido: IPedido[]; endereco: IEndereco; isChecked: boolean } = state

    const [nome, setNome] = useState<string>("")
    const [telefone, setTelefone] = useState<string>("")

    const valorTotal = listaPedido.flatMap(x => x.valor).reduce((acc, curr) => acc + curr, 0)

    const handlePedido = async () => {
        if (!isChecked) {

            const criarRetirada = async (nome: string, telefone: string): Promise<number> => {
                const user = {
                    nome,
                    telefone,
                    date: new Date().toISOString(),
                }
                const response = await api.post('Retirada', user)
                return response.data.id
            }

            const idPedido = await criarRetirada(nome, telefone)

            listaPedido.forEach(async (element) => {
                const pedido = {
                    valor: element.valor,
                    tamanho: element.tamanho,
                    pedidoRetiradaId: idPedido,
                    mistura: element.mistura,
                    guarnicao: element.guarnicao
                }
                await api.post('pedido', pedido)
            })

        }

        if (isChecked) {

            const criarRetirada = async (nome: string, telefone: string): Promise<number> => {
                const user = {
                    nome,
                    telefone,
                    nomeRua: endereco.nomeRua,
                    numeroRua: endereco.numeroRua,
                    bairro: endereco.bairro,
                    cidade: endereco.cidade,
                    date: new Date().toISOString(),
                }
                const response = await api.post('Entrega', user)
                return response.data.id
            }

            const idPedido = await criarRetirada(nome, telefone)

            listaPedido.forEach(async (element) => {
                const pedido = {
                    valor: element.valor,
                    tamanho: element.tamanho,
                    pedidoEntregaId: idPedido,
                    mistura: element.mistura,
                    guarnicao: element.guarnicao
                }
                await api.post('pedido', pedido)
            })
        }

    }

    const handleNome = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { value } = e.target
        setNome(value)
    }

    const handleTelefone = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { value } = e.target
        setTelefone(value)
    }

    return (<Container>

        <Wrapper>
            {listaPedido.map(({ mistura, guarnicao, pedido, tamanho, valor }) => (<>
                <div key={pedido}>

                    <p> Pedido: {pedido}   </p>

                    <p> Misturas: {mistura[0] === mistura[1] ? `2x ${mistura[0]}` : `${mistura.join(', ')}`}  </p>

                    <p> Guarnições : {
                        Object.entries(
                            guarnicao.reduce((acc: Record<string, number>, item: string) => {
                                acc[item] = (acc[item] || 0) + 1;
                                return acc;
                            }, {}))
                            .map(([item, count]) => count > 1 ? `${count}x ${item}` : item)
                            .join(', ')
                    }  </p>

                    <p> Tamanho: {tamanho}</p>

                    <p> Valor: {valor}</p>


                </div>
            </>))}

            <div key={valorTotal}>
                <p>Valor Total: {valorTotal}</p>
                <p> {isChecked ?
                    "" :
                    "Pedido para retirada no local"
                }</p>
            </div>

            <div>
                <label>Nome</label>
                <input name="nome" placeholder="Nome: "
                    onChange={handleNome} />

                <label>Telefone</label>
                <input name="telefone" placeholder="Telefone: "
                    onChange={handleTelefone} />
            </div>
            <Button title={"Concluir Pedido"} onClick={() => handlePedido()} />
        </Wrapper>


    </Container>)
}