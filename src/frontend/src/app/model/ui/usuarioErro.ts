export interface Welcome {
    errors:  Errors;
    type:    string;
    title:   string;
    status:  number;
    traceId: string;
}

export interface Errors {
    Nome:           string[];
    EscolaridadeId: string[];
    DataNascimento: string[];
}