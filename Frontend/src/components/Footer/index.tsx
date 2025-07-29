import { useState } from "react";
import { FooterContent } from "./styles";
import { IFooterContent } from "./types";

export const Footer = ({ title, $primary, onChangeTamanho, tamanhoSelecionado }: IFooterContent) => {

    return (
        <FooterContent $primary={$primary}>

            <div>

                <label><input name="tamanho" type="radio" value="P"
                    
                    onChange={(e) => onChangeTamanho(e.target.value)} /> <span>P:R$17,00 </span></label>

                <label><input name="tamanho" type="radio" value="M"
                    
                    onChange={(e) => onChangeTamanho(e.target.value)} /> <span>M:R$20,00 </span></label>

                <label><input name="tamanho" type="radio" value="G"
                    
                    onChange={(e) => onChangeTamanho(e.target.value)} /> <span>G:R$22,00 </span></label>

            </div>

            <div>
                <p> {title}</p>
            </div>

        </FooterContent>
    )
}
