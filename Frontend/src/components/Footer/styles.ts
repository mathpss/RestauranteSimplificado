import styled from "styled-components";

export const FooterContent = styled.div<{$primary:boolean}>`

    width:100%;
    height: 10%;
    padding:5px;

    display: column;
    place-items: center;

    margin: 0 auto;

    p{
    color: #ffffff;
    font-size: 28px;
    font-weight: 600; 
    font-style: italic;
    text-align:center;
    }

    label{
    color: #ffffff;
    margin: 8px;
    }

    input{
    display: ${({ $primary }) => $primary ? "inline" : "none"};
    
    }

    input:checked {
    border: none;
    outline: 2px solid deeppink;
    }
    
    `