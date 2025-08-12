import { ButtonContainer } from './styles'
import { IButton } from './types'

export default function Button({title, onClick, $secondary }: IButton) {
    return (
      <ButtonContainer $secondary onClick={onClick}>
  
          {title}      
            
      </ButtonContainer>
    )
  }