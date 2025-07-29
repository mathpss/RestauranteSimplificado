import styled from "styled-components";

export const WrapperEndereco = styled.div`
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
`

export const TextRetirada = styled.div`

        
        display: flex;         
        align-items: center;
        justify-content: space-between;

        font-style: normal;
        font-weight: 700;
        font-size 32px;
        color: #fff;

        padding: 5px;

        height: 60px;
        width:80%;

`


export const SwitchContainer = styled.label`
     display: inline-flex;

     align-items: center;
     cursor: pointer;
    `;

export const SwitchInput = styled.input`
    display: none;
    
    &:checked + span {
    background-color: #F2A516;
    }

    &:checked + span::before {
    transform: translateX(60px);
    }
    `;

export const SwitchSlider = styled.span`
     width: 80px;
     height: 20px;
     background-color: #ccc;
     border-radius: 20px;
     position: relative;
     transition: background-color 0.3s;

     &::before {
     content: '';
     position: absolute;
     width: 18px;
     height: 18px;
     background: white;
     border-radius: 50%;
     top: 1px;
     left: 1px;
     transition: transform 0.3s;
     }
    `

export const Accordion = styled.div<{isOpen?:boolean}>`
     margin-top: 10px;
     max-height: ${({ isOpen }) => (isOpen ? '400px' : '0')};
     overflow: hidden;
     transition: max-height 0.3s ease;
     background: #303030;
     width:80%;
     padding: ${({ isOpen }) => (isOpen ? '10px' : '0 10px')};
     
         p{
    color: #ffffff;
    font-size: 16px;
    font-weight: 300; 
    }

    `

    export const InputText = styled.input`
        background-color: transparent;
        color: #FFFFFF;
        width: 100%;
        border: 0;
        height:30px;
        border-bottom: 1px solid #ccc;
        margin-bottom: 8px;
    `
