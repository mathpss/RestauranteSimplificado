import styled from "styled-components";

export const Container = styled.main`
    background: #252526;
    width: 100vw;
    height: 100%;
    min-height: 100vh;
    color: #fff;
    
    position: relative;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
`

export const Wrapper = styled.div`

    width: 80%;
    height: 100%;
    
    
    border-radius: 8px;
    padding:  30px 15px;
    margin-bottom: 16px;
    position: relative;
    background: #303031ff;
    border: none;

    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
  
    gap: 5px;

    div{
    border: solid 2px #F2A516;
    border-radius: 8px;
    width: 80%;
    height: 100%;
    padding:  30px 15px;
    }
    label{
    color: #fff;
    }

    input{
    background-color: #303031ff;
    color: #fff;
    width: 100%;
    border: 0;
    height:30px;
    margin-bottom: 4px;
    border-bottom: solid 1px #FFF;
    }

    input:placeholder-shown{
    
    }

`