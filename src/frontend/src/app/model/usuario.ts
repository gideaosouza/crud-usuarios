import { Escolaridade } from "./escolaridade";

export interface Usuario{
    id: number;
    nome :string;
    sobrenome:string;
    email:string;
    dataNascimento:Date;
    escolaridadeId : number;
    escolaridade: Escolaridade;

}