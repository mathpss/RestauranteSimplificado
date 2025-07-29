export interface ICardPedido {
    title: string,
    onClickPlus?: (e: React.MouseEvent<HTMLButtonElement>) => void,
    onClickLess?: (e: React.MouseEvent<HTMLButtonElement>) => void,
    value?: number,
    onChange?: (e: React.ChangeEvent<HTMLInputElement>) => void,
    $primary: boolean
}