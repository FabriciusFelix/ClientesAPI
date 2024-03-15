import { Component, OnInit } from '@angular/core';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';


@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrl: './clientes.component.css'
})
export class ClientesComponent implements OnInit {
  formulario: any;
  tituloFormulario:string = '';

constructor(){
  this.formulario = new FormGroup({});
}
  ngOnInit(): void {
    this.formulario = new FormGroup({
      id : new FormGroup(null)
,     nome:new FormGroup(''),
      sobrenome:new FormGroup(''),
      codigoCpf:new FormGroup(''),
      email:new FormGroup(''),
      dataNascimento:new FormGroup(''),
      endereco:new FormGroup(''),
      ativo:new FormGroup(''),
      criadoEm: new FormGroup('')
    })
    this.tituloFormulario = 'Novo CLiente';
  }
}
