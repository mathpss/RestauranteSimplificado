export interface IFooterContent {
    title: string,
    $primary: boolean,
    tamanhoSelecionado?: string;
    onChangeTamanho: (valor: string) => void;
}