import styled from "styled-components";

export const Container = styled.main`
    background: #252526;
    width: 100vw;
    
    color: #fff;
    
    position: relative;
    display: flex;
    flex-direction: row;
    justify-content: center;
    
`

export const LateralBar = styled.div`
    min-width:130px;
    width: 20vw;
    min-height: 100vh;
    height: max-content;

    border-right: solid 1px #303031ff;
    padding:4px;
    color:#ffffff;

    display: flex; 
    flex-direction: column;
    
`

export const Content = styled.div`
    padding: 12px;
`

export const ContentCardapio = styled.div<({isOpen:boolean})>`
    display: ${({ isOpen }) => (isOpen ? 'flex' : 'none')};
    flex-direction: column;
    justify-content: center;
    
    padding: 5px;

    max-height: 100%;
    max-width: 100%;

    div{
    display: flex;
    flex-direction: row;
    justify-content: safe center;
    
    }
    
`

export const ContentPedidosHoje = styled.div<({isOpen:boolean})>`
    display: ${({ isOpen }) => (isOpen ? 'flex' : 'none')};
    flex-direction: column;

    padding: 5px;

    max-height: 100%;
    max-width: 100%;
    overflow: hidden;
`

export const TextCardapio = styled.p`
        font-style: normal;
        font-weight: 700;
        font-size 32px;
        color: #fff;
        
`

export const WrapperContent = styled.div`
    width: 100%;
    height: 100%;
    padding: 5px;
`