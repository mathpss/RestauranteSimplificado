import { ButtonContainer } from './styles'
import { IButton } from './types'

export default function Button({title, onClick }: IButton) {
    return (
      <ButtonContainer onClick={onClick}>
  
          {title}      
            
      </ButtonContainer>
    )
  }