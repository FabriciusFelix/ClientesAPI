import { Component, OnInit } from '@angular/core';
import { Form, FormControl, FormGroup } from '@angular/forms';
import { ClienteService } from './cliente.service';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { ICliente } from './ICliente';
@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit{
  formulario:FormGroup;
  tituloFormulario:string = '';
  teste = 0;
  public testeGet:any;
  public clientes:any = [
    
  ];
  constructor(private http:HttpClient) {
    this.formulario = new FormGroup({})

  }
  ngOnInit(): void {

    this.formulario = new FormGroup({
      id: new FormControl(null),
      nome:new FormControl(''),
      sobrenome:new FormControl(''),
      codigoCpf:new FormControl(''),
      email:new FormControl(''),
      dataNascimento:new FormControl(''),
      endereco:new FormControl(''),
      ativo:new FormControl(''),
      criadoEm: new FormControl('')
    })
    this.tituloFormulario = 'Novo Cliente ';
    this.getClientes();
  }


  public getClientes(): void{

    this.testeGet = this.http.get('http://localhost:5235/api/Clientes').subscribe(
      response => this.clientes = response,
      error => console.log(error)
    );
  }

  public postClientes(formData:FormGroup): void{
    this.teste++;
    console.log(formData.value[0]);
    console.log(formData.value[3]);
    console.log(formData.value[4]);
    alert(this.formulario.value[4])
  }
}
