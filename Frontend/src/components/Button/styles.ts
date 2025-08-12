import styled from "styled-components";

export const ButtonContainer = styled.button<{$secondary?:boolean}>`

    background-color: #F2A516;
    border-radius: 22px;

    color: #fff;
    padding: 4px 8px;
    min-width: 120px;
    width: ${$secondary => $secondary ? '20%' : '60%'} ;
    white-space: nowrap;

    margin: 12px auto;
    display: block;
`
