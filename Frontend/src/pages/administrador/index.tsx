import { LateralBar, Content, WrapperContent, ContentCardapio, TextCardapio, Container, ContentPedidosHoje } from "./styles"
import { useEffect, useState } from "react"
import { api } from "../../services/Api" 
import Button from "../../components/Button" 
import { ICardapio, IPedidoRetiradaHoje } from "./types"
import { Tema } from "../../components/Tema"

export const Administrador = ()=>{

    const [isCheckedCardapio, setIsCheckedCardapio] = useState<boolean>(false)
    const [isCheckedPedidosHoje, setIsCheckedPedidosHoje] = useState<boolean>(false)

    const [retiradaHoje, setRetiradaHoje] = useState<IPedidoRetiradaHoje[] | null>(null)

        const [cardapio, setCardapio] = useState<ICardapio | null>(null)
        const [mistura, setMistura] = useState<string[] | undefined>([])
        const [guarnicao, setGuarnicao] = useState<string[] | undefined>([])

    useEffect(() => {

        api.get('Cardapio')
            .then((res) => {
                setCardapio(res.data)
                //setLoading(false)
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

    
    const OpenCardapio = () => {
        if (isCheckedPedidosHoje === true) {
            setIsCheckedPedidosHoje(false)
            setIsCheckedCardapio(!isCheckedCardapio)
        }
        setIsCheckedCardapio(!isCheckedCardapio)
    }
    
    const OpenPedidosHoje = () => {
        if (isCheckedCardapio === true) {
            setIsCheckedCardapio(false)
            setIsCheckedPedidosHoje(!isCheckedPedidosHoje)
        }
        setIsCheckedPedidosHoje(!isCheckedPedidosHoje)
    }


    const handleTeste = () => {
        console.log("somente teste")
    }


    const handlePedidosHoje = () => {
          api.get('Retirada/Hoje').then(res=> setRetiradaHoje(res.data))
         //await api.get('Entrega/Hoje').then(res => set)



    }



    console.log(retiradaHoje)

    
    return (<>
        
        <Container>

            <LateralBar>
                    <Button onClick={OpenCardapio} title={"Cardápio"}></Button>
                    <Button onClick={OpenPedidosHoje} title={"Pedidos do Dia"}></Button>
                    
            </LateralBar>
                
            <WrapperContent>
                <Content>
                        <ContentCardapio isOpen={isCheckedCardapio} >
                            
                            {mistura?.map((item, index) => (
                                <div key={index}>
                                    <TextCardapio> {item}</TextCardapio>
                                    <Button $secondary onClick={()=>handleTeste()} title={"update"}></Button>
                                </div>
                            ))}

                            
                            {guarnicao?.map((item, index) => (
                                <div key={index}>
                                    <TextCardapio> {item}</TextCardapio>
                                    <Button $secondary onClick={()=> handleTeste()} title="update"/>
                                </div>
                            ))}

                        </ContentCardapio>

                    <ContentPedidosHoje isOpen={isCheckedPedidosHoje}>
                        <table>
                            <thead>
                                    <tr>
                                        <th>
                                        Retirada    
                                        </th>
                                        
                                        <th>
                                        Entrega    
                                        </th>
                                    </tr>          
                            </thead>
                            
                            <tbody>

                                <tr >
                                    <td>

                                    </td>

                                    <td>
                                        
                                    </td>

                                </tr>
                                
                            </tbody>    


                        </table>


                    </ContentPedidosHoje>
                    
                </Content>

            </WrapperContent>

        </Container>
              
    </>
    )
    
}