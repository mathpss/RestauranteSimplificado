import { TextRetirada, WrapperEndereco, Accordion, SwitchContainer, SwitchInput, SwitchSlider, InputText } from "./styles";
import { ICardEndereco } from "./types";

export default function CardEndereco({ title1, title2, onChangeRua,onChangeNumero, onChangeBairro, onChangeCidade, isChecked, onChangeSwitch }: ICardEndereco) {

    return (
        <WrapperEndereco>
            <TextRetirada>
                <h2>{title1}</h2>
                <h2>{title2}</h2>
            </TextRetirada>


            <SwitchContainer>
                <SwitchInput
                    type="checkbox"
                    checked={isChecked}
                    onChange={onChangeSwitch}
                />
                <SwitchSlider />
            </SwitchContainer>

            <Accordion isOpen={isChecked}>
                <p>Insira o local da entrega</p>
                <InputText name="nomeRua" onChange={onChangeRua} placeholder="Nome da Rua"/>
                <InputText name="numeroRua" onChange={onChangeNumero} type="number" placeholder="Número da Rua"/>
                <InputText name="bairro" onChange={onChangeBairro} placeholder="Bairro"/>
                <InputText name="cidade" onChange={onChangeCidade} placeholder="Cidade"/>
            </Accordion>
        </WrapperEndereco>
    )
}