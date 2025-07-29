import { Card, ButtonCounter, ContainerButton, ContainerCounter, TextPedido } from "./styles";
import { ICardPedido } from "./types";
export const CardPedido = ({title, onClickPlus, onClickLess, value, onChange, $primary}: ICardPedido) => {
    
    return (<>
        <Card $primary={$primary}>
            <TextPedido>
            {title}

            </TextPedido>

            <ContainerButton $primary={$primary}>
                
                <ButtonCounter onClick={onClickLess}>-</ButtonCounter>
                <ContainerCounter> <input value={value} onChange={onChange} /> </ContainerCounter>               
                <ButtonCounter onClick={onClickPlus}>+</ButtonCounter>

            </ContainerButton>            

        </Card>
        <hr/>
    
    </>)
}