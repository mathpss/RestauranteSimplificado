import { IHeader } from "./types";
import { HeaderContent } from "./styles";

export const Header = ({title}: IHeader) => {
    
    return (
        <HeaderContent>  <h1>{ title }</h1> </HeaderContent>
    )

}