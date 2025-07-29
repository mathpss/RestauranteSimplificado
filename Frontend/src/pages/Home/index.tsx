import { Footer } from "../../components/Footer"
import { Header } from "../../components/Header"
import { CardPedido } from "../../components/CardPedido"
import { Main } from "../../components/Main"
import Button from "../../components/Button"
import { useNavigate } from "react-router-dom"
import { useEffect, useState } from "react"
import { api } from "../../services/Api"
import { ICardapio } from "./types"
import { Tema } from "../../components/Tema"
import Skeleton from 'react-loading-skeleton'
import 'react-loading-skeleton/dist/skeleton.css'
import { CardSkeleton } from "../../components/CardSkeleton"

function Home() {

    const navigate = useNavigate();

    const [loading, setLoading] = useState<boolean>(true)
    const [cardapio, setCardapio] = useState<ICardapio | null>(null)
    const [mistura, setMistura] = useState<string[] | undefined>([])
    const [guarnicao, setGuarnicao] = useState<string[] | undefined>([])

    const dayweek = new Date().toLocaleString('pt-BR', { weekday: 'long' })
    const dayweekFormated = dayweek.charAt(0).toUpperCase() + dayweek.slice(1)
    const footer = "Rua: Tijuca, 22 Jd Guanabara\n\nEsquina com Av Europa"

    useEffect(() => {

        api.get('Cardapio')
            .then((res) => {
                setCardapio(res.data)
                setLoading(false)
            })
            .catch((error) => {
                console.error("Erro ao buscar o cardapio", error)
            })
    }, [])

    useEffect(() => {
        if (cardapio !== null && cardapio.guarnicao.length > 0) {

            setMistura(cardapio?.mistura.split(',').map(item => item.trim()))
            setGuarnicao(cardapio.guarnicao.split(',').map(item => item.trim()))

        }
    }, [cardapio])

    const handlePedido = () => {
        navigate('/pedido', { state: { mistura, guarnicao } })
    }

    const handleTamanhoChange = (novoTamanho: string) => {
    
  };

    return (<>

        <Main>

            <Header title={dayweekFormated} />

            <Tema children="Misturas (2 opções)" />

            {loading && <CardSkeleton cards={8} />}
            
            {mistura?.map((item, index) => (
                <CardPedido key={index} title={item}
                    $primary={false} />
            ))}

            <Tema children="Guarnições (3 opções)" />

            {loading && <CardSkeleton cards={8} />}

            {guarnicao?.map((item, index) => (
                <CardPedido key={index} title={item} $primary={false} />
            ))}

            <Button title="Montar Pedido" onClick={handlePedido} />

            <Footer title={footer} $primary={false} onChangeTamanho={handleTamanhoChange}/>

        </Main>

    </>)
}

export { Home }