import { LateralBar, Content, WrapperContent, ContentCardapio, TextCardapio, Container, ContentPedidosHoje } from "./styles"
import { useEffect, useState } from "react"
import { api } from "../../services/Api" 
import Button from "../../components/Button" 
import { IPedidoRetiradaHoje } from "./types"

export const Administrador = ()=>{

    const [isCheckedCardapio, setIsCheckedCardapio] = useState<boolean>(false)
    const [isCheckedPedidosHoje, setIsCheckedPedidosHoje] = useState<boolean>(false)

    const [retiradaHoje, setRetiradaHoje] = useState<IPedidoRetiradaHoje[] | null>(null)

    useEffect(() => {
        const listCardapio = async () => {
            const response = await api.get(`Cardapio`)            
        }
        listCardapio()
    }, [])

    
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

        
        
        <LateralBar>teste
                <Button onClick={OpenCardapio} title={"Cardápio"}></Button>
                <Button onClick={OpenPedidosHoje} title={"Pedidos do Dia"}></Button>
                
        </LateralBar>
            

        <WrapperContent>
            <Content>
                <ContentCardapio isOpen={isCheckedCardapio} >
                    
                    <TextCardapio> testezinho maroto mas realmente só para teste</TextCardapio>
                    <Button onClick={()=>handleTeste()} title={"update"}></Button>

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
                            
                        </tbody>    


                    </table>


                </ContentPedidosHoje>
                
            </Content>

        </WrapperContent>

        </Container>
              
    </>
    )
    
}