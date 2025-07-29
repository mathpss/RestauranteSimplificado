import { Container, Content } from "./styles";
import { IMain } from "./types";

export const Main = ({children}: IMain) => {
    
    return (
        <Container>
            <Content>
                {children}
            </Content>

        </Container>
    )

}