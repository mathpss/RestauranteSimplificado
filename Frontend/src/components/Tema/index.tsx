import { TemaContent } from "./styles";
import { ITema } from "./types";

export const Tema = ({children}:ITema) => {
    
    return (<TemaContent>
        {children}
    </TemaContent>)
}