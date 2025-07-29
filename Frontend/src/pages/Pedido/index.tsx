import { Footer } from "../../components/Footer"
import { CardPedido } from "../../components/CardPedido"
import { Main } from "../../components/Main"
import Button from "../../components/Button"
import { useNavigate, useLocation } from "react-router-dom"
import { useState, useEffect } from "react"
import { Tema } from "../../components/Tema"
import { IEndereco, ILocation, IPedido } from "./types"
import CardEndereco from "../../components/CardEndereco"

export const Pedido = () => {

    const navigate = useNavigate()
    const location = useLocation()

    const footer = "Rua: Tijuca, 22 Jd Guanabara\n\nEsquina com Av Europa"
    const { mistura, guarnicao } = location.state as ILocation

    const [tamanho, setTamanho] = useState<string>("P");
    const [countPedido, setCountPedido] = useState<number>(1)
    const [countMisturas, setCountMisturas] = useState<number[]>([])
    const [countGuarnicoes, setCountGuarnicoes] = useState<number[]>([])
    const [isChecked, setIsChecked] = useState<boolean>(false);

    const [endereco, setEndereco] = useState<IEndereco>({
        nomeRua: "",
        numeroRua: "",
        bairro: "",
        cidade: "",
    })

    const [listaPedido, setListaPedido] = useState<IPedido[]>([])

    useEffect(() => {
        if (mistura.length > 0) {
            setCountMisturas(Array(mistura.length).fill(0))
        }
    }, [mistura])

    useEffect(() => {
        if (guarnicao.length > 0) {
            setCountGuarnicoes(Array(guarnicao.length).fill(0))
        }
    }, [guarnicao])

    const handleCounterPlusPedido = () => {
        if (countPedido > 0) {
            setCountPedido(prev => prev += 1)
        }
    }

    const handleCounterLessPedido = () => {
        if (countPedido > 1) {
            setCountPedido(prev => prev -= 1)
        }
    }

    const handlerCounterPlusMistura = (index: number) => {

        const copiaArray = [...countMisturas]
        const total = copiaArray.reduce((acumulador, valor) => acumulador + valor, 0)
        if (total < 2) {
            copiaArray[index] += 1
            setCountMisturas(copiaArray)
        }
    }

    const handlerCounterLessMistura = (index: number) => {
        const copiaArray = [...countMisturas]
        if (copiaArray[index] > 0) {
            copiaArray[index] -= 1
            setCountMisturas(copiaArray)
        }
    }

    const handlerCounterPlusGuarnicao = (index: number) => {

        const copiaArray = [...countGuarnicoes]
        const total = copiaArray.reduce((acumulador, valor) => acumulador + valor, 0)
        if (total < 3) {
            copiaArray[index] += 1
            setCountGuarnicoes(copiaArray)
        }
    }

    const handlerCounterLessGuarnicao = (index: number) => {
        const copiaArray = [...countGuarnicoes]
        if (copiaArray[index] > 0) {
            copiaArray[index] -= 1
            setCountGuarnicoes(copiaArray)
        }
    }

    const handleTamanhoChange = (novoTamanho: string) => {
    setTamanho(novoTamanho);
  };

    const handleConfirmação = () => {

        const novaMistura: string[] = []
        const novaGuarnicao: string[] = []
        const novoTamanho = tamanho

        mistura.forEach((item, index) => {
            for (let i = 0; i < countMisturas[index]; i++) {
                novaMistura.push(item)
            }
        })

        guarnicao.forEach((item, index) => {
            for (let i = 0; i < countGuarnicoes[index]; i++) {
                novaGuarnicao.push(item)
            }
        })

        const novoPedido: IPedido = {
            pedido: listaPedido.length + 1,
            mistura: novaMistura,
            guarnicao: novaGuarnicao,
            valor: novoTamanho === "P" ? 17 : novoTamanho === "M" ? 20 : novoTamanho === "G" ? 22 : 0,
            tamanho: novoTamanho
        }

        const novaListaPedido = [...listaPedido, novoPedido]
        setListaPedido( novaListaPedido)

        if (guarnicao.length > 0) {
            setCountGuarnicoes(Array(guarnicao.length).fill(0))
        }
        if (mistura.length > 0) {
            setCountMisturas(Array(mistura.length).fill(0))
        }

        window.scrollTo({
            top: 100,
            left: 0,
            behavior: "smooth"
        });
        if (listaPedido.length + 1 === countPedido) {
            navigate('/confirmacao', { state: {listaPedido: novaListaPedido, endereco, isChecked} } )
        }
    }

    const handleSwitch = () => {
        setIsChecked(!isChecked)
    }

    const handleChangeEndereco = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setEndereco({
            ...endereco, [name]: value
        });

    }
    
    console.log(endereco)
    
    return (<>

        <Main>

            <CardPedido title="Informe a quantidade desejada" $primary
                value={countPedido}
                onClickPlus={() => handleCounterPlusPedido()}
                onClickLess={() => handleCounterLessPedido()}
            />

            <CardEndereco title1={"Retirada"} title2={"Entrega"}
                onChangeRua={handleChangeEndereco}
                onChangeNumero={handleChangeEndereco}
                onChangeBairro={handleChangeEndereco}
                onChangeCidade={handleChangeEndereco}
                isChecked={isChecked}
                onChangeSwitch={handleSwitch} />

            <Tema children="Misturas (2 opções)" />

            {mistura?.map((item, index) => (
                <CardPedido key={index} title={item}
                    $primary={true}
                    value={countMisturas[index]}
                    onClickPlus={() => handlerCounterPlusMistura(index)}
                    onClickLess={() => handlerCounterLessMistura(index)} />
            ))}

            <Tema children="Guarnições (3 opções)" />
            {guarnicao?.map((item, index) => (
                <CardPedido key={index} title={item}
                    $primary={true}
                    value={countGuarnicoes[index]}
                    onClickPlus={() => handlerCounterPlusGuarnicao(index)}
                    onClickLess={() => handlerCounterLessGuarnicao(index)} />
            ))}
            
            <Button title={`Montar o Pedido ${listaPedido.length + 1}`} onClick={handleConfirmação} />

            <Footer title={footer} $primary onChangeTamanho={handleTamanhoChange} />

        </Main>

    </>)
}
