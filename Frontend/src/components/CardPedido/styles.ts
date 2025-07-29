import styled from "styled-components";

export const Card = styled.div<{ $primary?: boolean; }>`
    display: flex; 
    flex-direction: row;
    align-items: center;
    justify-content: ${({$primary})=> $primary ? "space-between;" : "center;"}

    height: 60px;

    padding: 12px;
    
`

export const TextPedido = styled.p`

        font-style: normal;
        font-weight: 700;
        font-size 32px;
        color: #fff;

`
export const ButtonCounter = styled.button`

    background-color: #F2A516;
    border-radius: 50%;
    
    color: #fff;

    width: 35px;
    height: 35px;

    
`

export const ContainerButton = styled.div<{ $primary?: boolean; }>`
    ${({$primary})=> $primary ?
  `
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    gap: 4px;

    `
    
    : "display: none;"}
`

export const ContainerCounter = styled.div`

    
    input{
        font-style: normal;
        font-weight: 700;
        font-size 32px;
        color: #fff;
        width: 35px;
        height: 35px;
        background-color:rgb(76, 78, 76);
        text-align:center;
        
    }
`