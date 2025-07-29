export interface ICardEndereco{
    title1?:string,
    title2?:string,
    onChangeRua?: (e: React.ChangeEvent<HTMLInputElement>)=> void,
    onChangeNumero?:(e: React.ChangeEvent<HTMLInputElement>)=> void,
    onChangeBairro?:(e: React.ChangeEvent<HTMLInputElement>)=> void,
    onChangeCidade?:(e: React.ChangeEvent<HTMLInputElement>)=> void,
    isChecked?:boolean,
    onChangeSwitch?:(e: React.ChangeEvent<HTMLInputElement>)=> void
}