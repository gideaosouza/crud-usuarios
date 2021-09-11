  
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Escolaridade } from '../model/escolaridade';

@Injectable({
    providedIn: 'root'
})

export class EscolaridadeService {

    private apiServer = "https://localhost:5001";

    constructor(private httpClient: HttpClient) { }
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }    

    create(escolaridade: Escolaridade): Observable<Escolaridade> {
        return this.httpClient.post<Escolaridade>(this.apiServer + '/escolaridade/', JSON.stringify(escolaridade), this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }
    getById(id: string): Observable<Escolaridade> {
        return this.httpClient.get<Escolaridade>(this.apiServer + '/escolaridade/' + id)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    getAll(): Observable<Escolaridade[]> {
        return this.httpClient.get<Escolaridade[]>(this.apiServer + '/escolaridade/')
            .pipe(
                catchError(this.errorHandler)
            )
    }

    update(id: number, escolaridade: Escolaridade): Observable<Escolaridade> {
        return this.httpClient.put<Escolaridade>(this.apiServer + '/escolaridade/' + id, JSON.stringify(escolaridade), this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }
    errorHandler(error: any) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            errorMessage = error.error.message;
        }
        return throwError(error.error);
    }
}