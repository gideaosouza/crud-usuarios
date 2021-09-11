  
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Usuario } from '../model/usuario';

@Injectable({
    providedIn: 'root'
})

export class UsuarioService {

    private apiServer = "https://localhost:5001";

    constructor(private httpClient: HttpClient) { }
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }    

    create(usuario: Usuario): Observable<Usuario> {
        return this.httpClient.post<Usuario>(this.apiServer + '/usuario/', JSON.stringify(usuario), this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }
    getById(id: string): Observable<Usuario> {
        return this.httpClient.get<Usuario>(this.apiServer + '/usuario/' + id)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    getAll(): Observable<Usuario[]> {
        return this.httpClient.get<Usuario[]>(this.apiServer + '/usuario/')
            .pipe(
                catchError(this.errorHandler)
            )
    }

    update(id: number, usuario: Usuario): Observable<Usuario> {
        return this.httpClient.put<Usuario>(this.apiServer + '/usuario/' + id, JSON.stringify(usuario), this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    delete(id: number): Observable<Usuario> {
        return this.httpClient.delete<Usuario>(this.apiServer + '/usuario/' + id, this.httpOptions)
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