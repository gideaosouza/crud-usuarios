import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { Escolaridade } from '../../model/escolaridade';
import { Alert } from '../../model/ui/Alert';
import { Usuario } from '../../model/usuario';
import { EscolaridadeService } from '../../services/escolaridadeService';
import { UsuarioService } from '../../services/usuarioService';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {

  dismissible = true;
  escolaridadeValue: any;
  public usuarios: Usuario[] = [];
  public escolaridades: Escolaridade[] = [];
  public usuarioForm!: FormGroup;
  public  alerts!: Alert[];

  onClosed(dismissedAlert: any): void {
    this.alerts = this.alerts.filter(alert => alert !== dismissedAlert);
  }

  constructor(public usuarioService: UsuarioService, public fb: FormBuilder, public escolaridadeService: EscolaridadeService, private localeService: BsLocaleService)
   {}
  ngOnInit(): void {
    
    this.usuarioForm = this.fb.group({
      escolaridadeId:0,
      id: 0,
      nome: [''],
      sobrenome: [''],
      email: [''],
      dataNascimento: ['']    
    })
    this.alerts = [];

    this.usuarioService.getAll().subscribe((data: Usuario[]) => {
      this.usuarios = data;
    })
    
    this.escolaridadeService.getAll().subscribe((data: Escolaridade[]) => {
      this.escolaridades = data;
    })

  }

  update(id: number) {
    let obj = this.usuarios.find(c => c.id == id)

    let date = new Date(obj!.dataNascimento).toLocaleDateString("pt-br");


    this.usuarioForm.setValue({
      nome:obj!.nome,
      sobrenome:obj!.sobrenome,
      email: obj!.email,
      dataNascimento: date,
      escolaridadeId: obj!.escolaridadeId,
      id: id
    })
  }

  submitForm() {
    if (this.usuarioForm.controls.id.value == 0)
      this.adiciona()
    else
      this.atualiza();
  }

  manipulaErros(erro : any) {
    let errorValidation = erro as any

    errorValidation.errors?.Email?.forEach((element: string) => {
      this.alerts.push({
        type: 'danger',
        message: 'Email: ' + element,
      })
    })
    errorValidation.errors?.Nome?.forEach((element: string) => {
      this.alerts.push({
        type: 'danger',
        message: 'Nome: ' + element,
      })
    })

    errorValidation.errors?.EscolaridadeId?.forEach((element: string) => {
      this.alerts.push({
        type: 'danger',
        message: 'Escolaridade: ' + element
      })
    })

    errorValidation.errors?.DataNascimento?.forEach((element: string) => {
      this.alerts.push({
        type: 'danger',
        message: 'Data de Nascimento: ' + element
      })
    })
  }

  adiciona() {
    
    let escolaridade = Number(this.usuarioForm.controls.escolaridadeId.value ?? 0);
    let date = this.usuarioForm.get('dataNascimento')?.value as string;
    
    let usuario = {
      nome: this.usuarioForm.controls.nome.value as string,
      sobrenome: this.usuarioForm.controls.sobrenome.value as string,
      dataNascimento: new Date(date),
      escolaridadeId: escolaridade,
      email: this.usuarioForm.controls.email.value as string
    } ;

    this.usuarioService.create(usuario as Usuario).subscribe(
      res => {
        this.alerts.push({
          type: 'success',
          message: 'Cadastro efetuado com Sucesso!',
        })
        this.usuarioService.getAll().subscribe((data: Usuario[]) => {
          this.usuarios = data;
        })
        this.usuarioForm = this.fb.group({
          escolaridadeId:0,
          id: 0,
          nome: [''],
          sobrenome: [''],
          email: [''],
          dataNascimento: ['']   
        })
      },
      (erro) => this.manipulaErros(erro))
  }

  atualiza() {
    let escolaridade = Number(this.usuarioForm.controls.escolaridadeId.value ?? 0);
    let date = this.usuarioForm.get('dataNascimento')?.value as string;
    let usuario = {
      nome: this.usuarioForm.controls.nome.value as string,
      sobrenome: this.usuarioForm.controls.sobrenome.value as string,
      dataNascimento: new Date(date),
      escolaridadeId: escolaridade,
      email: this.usuarioForm.controls.email.value as string
    } ;

    this.usuarioService.update(this.usuarioForm.controls.id.value, usuario as Usuario).subscribe(
      res => {
        this.alerts.push({
          type: 'success',
          message: 'Cadastro atualizado com Sucesso!',
        })
        this.usuarioService.getAll().subscribe((data: Usuario[]) => {
          this.usuarios = data;
        })
        this.usuarioForm = this.fb.group({
          escolaridadeId:0,
          id: 0,
          nome: [''],
          sobrenome: [''],
          email: [''],
          dataNascimento: ['']   
        })
      },
      (erro) => this.manipulaErros(erro))
  }

  delete(id:number) {

    this.usuarioService.delete(id).subscribe(
      res => {
        this.alerts.push({
          type: 'success',
          message: 'Cadastro deletado com Sucesso!',
        })
        this.usuarioService.getAll().subscribe((data: Usuario[]) => {
          this.usuarios = data;
        })
        this.usuarioForm = this.fb.group({
          escolaridadeId:0,
          id: 0,
          nome: [''],
          sobrenome: [''],
          email: [''],
          dataNascimento: ['']   
        })
      },
      (erro) => this.manipulaErros(erro))
  }

  changeEscolaridade(e:any) {
    this.usuarioForm.controls.escolaridadeId.setValue(
      e.target.value , {
      onlySelf: true
    })
  }

  close(alert: Alert) {
    this.alerts.splice(this.alerts.indexOf(alert), 1);
  }

  limpar(){
    this.usuarioForm = this.fb.group({
      escolaridadeId:0,
      id: 0,
      nome: [''],
      sobrenome: [''],
      email: [''],
      dataNascimento: ['']    
    })
  }
}
